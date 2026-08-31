using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;

UserRepository users = new UserRepository();
MessageRepository messages = new MessageRepository();
Dictionary<string, TcpClient> connectedUsers = new Dictionary<string, TcpClient>();
ContactRepository contacts = new ContactRepository();


TcpListener server = new TcpListener(IPAddress.Any, 5000);

server.Start();

Console.WriteLine("Messenger Server started...");
Console.WriteLine("Waiting for clients...");

while (true)
{
    TcpClient client = server.AcceptTcpClient();

    Console.WriteLine("Client connected.");

    // Handle this client separately
    Task.Run(() => HandleClient(client));
}


void HandleClient(TcpClient client)
{
    NetworkStream stream = client.GetStream();
    StreamReader reader = new StreamReader(stream, Encoding.UTF8);

    try
    {
        while (client.Connected)
        {
            string? message=reader.ReadLine();
            if(message == null)
            break;

            Console.WriteLine("Received: " + message);

            //for registration

            if (message.StartsWith("REGISTER:"))
            {
                string data = message.Substring("REGISTER:".Length);

                string[] parts = data.Split('|');

                if (parts.Length != 3)
                {
                    byte[] reply = Encoding.UTF8.GetBytes("REGISTER_FAILED" +
                        "n");
                    stream.Write(reply, 0, reply.Length);
                    continue;
                }

                string userId = parts[0];
                string username = parts[1];
                string password = parts[2];

                if (users.UserExists(userId))
                {
                    byte[] reply = Encoding.UTF8.GetBytes("REGISTER_EXISTS\n");
                    stream.Write(reply, 0, reply.Length);
                    continue;
                }

                bool registered =
                    users.RegisterUser(userId, username, password);

                string response = registered
                    ? "REGISTER_SUCCESS\n"
                    : "REGISTER_FAILED\n";

                byte[] responseData = Encoding.UTF8.GetBytes(response);

                stream.Write(responseData, 0, responseData.Length);

                continue;
            }
            //login
            if (message.StartsWith("LOGIN:"))
            {
                string data = message.Substring("LOGIN:".Length);

                string[] parts = data.Split('|', 2);

                if (parts.Length < 2)
                {
                    Console.WriteLine("Invalid LOGIN request: " + message);

                    byte[] reply = Encoding.UTF8.GetBytes("LOGIN_FAILED\n");
                    stream.Write(reply, 0, reply.Length);

                    continue;
                }

                string userId = parts[0];
                string password = parts[1];

                Console.WriteLine("Login attempt: " + userId);

                bool success = users.LoginUser(userId, password);

                if (success)
                {
                    Console.WriteLine("Login successful!");

                    connectedUsers[userId] = client;

                    byte[] reply = Encoding.UTF8.GetBytes("LOGIN_SUCCESS\n");
                    stream.Write(reply, 0, reply.Length); ;
                }
                else
                {
                    Console.WriteLine("Login failed!");

                    byte[] reply = Encoding.UTF8.GetBytes("LOGIN_FAILED\n");
                    stream.Write(reply, 0, reply.Length);
                }

                continue;
            }

            //SEND
            if (message.StartsWith("SEND_MESSAGE:"))
            {
                string data = message.Substring("SEND_MESSAGE:".Length);

                string[] parts = data.Split('|', 3);

                if (parts.Length < 3)
                    continue;

                string senderId = parts[0];
                string receiverId = parts[1];
                string messageText = parts[2];

                Console.WriteLine($"{senderId} -> {receiverId}: {messageText}");

                // Save message to SQL
                bool saved = messages.SaveMessage(
                    senderId,
                    receiverId,
                    messageText
                );

                if (!saved)
                {
                    Console.WriteLine("Failed to save message.");
                    continue;
                }

                // Send message to receiver
                if (connectedUsers.ContainsKey(receiverId))
                {
                    Console.WriteLine("Receiver found: " + receiverId);

                    TcpClient receiverClient = connectedUsers[receiverId];

                    NetworkStream receiverStream =receiverClient.GetStream();

                    string response =$"MESSAGE:{senderId}|{messageText}\n";

                    Console.WriteLine("Sending to receiver: " + response);

                    byte[] reply =Encoding.UTF8.GetBytes(response);

                    receiverStream.Write(reply, 0, reply.Length);
                }
                else
                {
                    Console.WriteLine("Receiver is NOT online: " + receiverId);
                }

                continue;
            }

            if (message.StartsWith("ADD_CONTACT:"))
            {
                string data = message.Substring("ADD_CONTACT:".Length);

                string[] parts = data.Split('|', 2);

                if(parts.Length != 2)
                {
                    byte[] reply = Encoding.UTF8.GetBytes("CONTACT_ADD_FAILED");
                    stream.Write(reply, 0, reply.Length);
                    continue;
                }

                string userId = parts[0];
                string contactUserId = parts[1];

                Console.WriteLine($"Adding contact: {userId} -> {contactUserId}");
                if (contacts.ContactExists(userId, contactUserId)){
                    byte[] reply = Encoding.UTF8.GetBytes("CONTACT_ALREADY_EXIST\n");
                    stream.Write(reply, 0, reply.Length);
                    continue;
                }

                contacts.AddContact(userId, contactUserId);
                byte[] response = Encoding.UTF8.GetBytes("CONTACT_ADD_SUCCESSFUL\n");
                stream.Write(response, 0, response.Length);

                continue;
            }

            if (message.StartsWith("LOAD_MESSAGES:"))
            {
                string data = message.Substring("LOAD_MESSAGES:".Length);

                string[] parts = data.Split('|', 2);

                if (parts.Length != 2)
                    continue;

                string userId = parts[0];
                string contactId = parts[1];

                Console.WriteLine($"Loading messages: {userId} <-> {contactId}");

                List<string[]> messageList =
                    messages.getMessage(userId, contactId);

                foreach (string[] msg in messageList)
                {
                    string response = $"OLD_MESSAGE:{msg[0]}|{msg[1]}|{msg[2]}|{msg[3]}\n";

                    byte[] reply=Encoding.UTF8.GetBytes(response);

                    stream.Write(reply, 0, reply.Length);
                }

                byte[] done=Encoding.UTF8.GetBytes("MESSAGES_LOADED\n");

                stream.Write(done, 0, done.Length);

                continue;
            }

            if (message.StartsWith("LOAD_CONTACTS:"))
            {
                string userId = message.Substring("LOAD_CONTACTS:".Length);

                Console.WriteLine("Loading contacts for: " + userId);

                List<string[]> contactList = contacts.getContacts(userId);

                foreach (string[] contact in contactList)
                {
                    string response =
                        $"CONTACT:{contact[0]}|{contact[1]}|Online\n";

                    byte[] reply = Encoding.UTF8.GetBytes(response);

                    stream.Write(reply, 0, reply.Length);
                }

                continue;
            }
            //Delete

            if(message.StartsWith("DELETE_MESSAGE:"))
            {
                string messageId = message.Substring("DELETE_MESSAGE:".Length);

                Console.WriteLine("Deleting message: " + messageId);

                bool deleted = messages.deleteMessage(messageId);

                string response = deleted ? "DELETE_SUCCESS\n" : "DELETE_FAILED\n";

                byte[] reply = Encoding.UTF8.GetBytes(response);

                stream.Write(reply, 0, reply.Length);

                continue;
            }

            // search
            if (message.StartsWith("SEARCH_USER:"))
            {
                string userId = message.Substring("SEARCH_USER:".Length);

                Console.WriteLine("Searching for: " + userId);

                if (users.UserExists(userId))
                {
                    string[]? user = users.GetUser(userId);

                    if (user != null)
                    {
                        string response = $"USER_FOUND|{user[0]}|{user[1]}|Online\n";

                        byte[] reply = Encoding.UTF8.GetBytes(response);

                        stream.Write(reply, 0, reply.Length);
                    }
                    else
                    {
                        byte[] reply = Encoding.UTF8.GetBytes("USER_NOT_FOUND\n");

                        stream.Write(reply, 0, reply.Length);
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(
            "Client error: " + ex.Message);
    }

    client.Close();

    Console.WriteLine("Client disconnected.");
}

