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

                if(userId == "admin" && password == "1444")
                {
                    Console.WriteLine("Admin login successful!");
                    byte[] reply = Encoding.UTF8.GetBytes("ADMIN_LOGIN_SUCCESS\n");
                    stream.Write(reply, 0, reply.Length);
                    continue;
                }

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
            //Admin Operations
            if (message.StartsWith("ADMIN_CHAT_HISTORY:"))
            {
                string userId = message.Substring("ADMIN_CHAT_HISTORY:".Length);
                Console.WriteLine("Admin requested chat history for: " + userId);
                List<string[]> chatHistory = messages.getUserChatHistory(userId);

                foreach (string[] msg in chatHistory)
                {
                    string response = $"CHAT_HISTORY:{msg[0]}|{msg[1]}|{msg[2]}|{msg[3]}\n";
                    byte[] reply = Encoding.UTF8.GetBytes(response);
                    stream.Write(reply, 0, reply.Length);
                }
              
                byte[] done =Encoding.UTF8.GetBytes("CHAT_HISTORY_END\n");

                stream.Write(done, 0, done.Length);

                continue;
            }
            if (message.StartsWith("ADMIN_SEARCH_USER:"))
            {
                string searchText =message.Substring("ADMIN_SEARCH_USER:".Length);

                Console.WriteLine("Admin searching: " + searchText);

                List<string[]> userList = users.SearchUsers(searchText);

                foreach (string[] user in userList)
                {
                    string response =$"ADMIN_USER:{user[0]}|{user[1]}|{user[2]}\n";
                    byte[] reply =Encoding.UTF8.GetBytes(response);
                    stream.Write(reply, 0, reply.Length);
                }

                byte[] done = Encoding.UTF8.GetBytes("ADMIN_SEARCH_END\n");
                stream.Write(done, 0, done.Length);

                continue;
            }
            if (message.StartsWith("ADMIN_UPDATE_USER:"))
            {
                string data =message.Substring("ADMIN_UPDATE_USER:".Length);
                string[] parts = data.Split('|', 3);

                if (parts.Length != 3)
                {
                    byte[] reply =Encoding.UTF8.GetBytes("ADMIN_UPDATE_FAILED\n");
                    stream.Write(reply, 0, reply.Length);

                    continue;
                }

                string userId = parts[0];
                string username = parts[1];
                string password = parts[2];

                Console.WriteLine($"Admin updating user {userId}");

                bool updated =users.UpdateUser(userId,username,password);

                string response = updated? "ADMIN_UPDATE_SUCCESS\n": "ADMIN_UPDATE_FAILED\n";

                byte[] responseData =Encoding.UTF8.GetBytes(response);

                stream.Write(responseData, 0, responseData.Length);

                continue;
            }

            if (message.StartsWith("ADMIN_DELETE_USER:"))
            {
                string userId=message.Substring("ADMIN_DELETE_USER:".Length);
                Console.WriteLine("Admin deleting user: " + userId);
                bool deleted = users.adminDelete(userId);
                string response = deleted ? "ADMIN_DELETE_SUCCESS\n" : "ADMIN_DELETE_FAILED\n";
                byte[] reply = Encoding.UTF8.GetBytes(response);
                stream.Write(reply, 0, reply.Length);
                continue;
            }

            if (message.StartsWith("ADMIN_GET_USER:"))
            {
                string userId = message.Substring("ADMIN_GET_USER:".Length).Trim();

                Console.WriteLine("Admin requesting user info: " + userId);

                string[]? user = users.GetUser(userId);

                if (user != null)
                {
                    string response = $"ADMIN_USER_INFO:{user[0]}|{user[1]}\n";

                    byte[] reply = Encoding.UTF8.GetBytes(response);

                    stream.Write(reply, 0, reply.Length);
                }
                else
                {
                    byte[] reply = Encoding.UTF8.GetBytes("ADMIN_USER_NOT_FOUND\n");

                    stream.Write(reply, 0, reply.Length);
                }

                continue;
            }

            // search
            if (message.StartsWith("SEARCH_USER:"))
            {
                string userId = message.Substring("SEARCH_USER:".Length).Trim();

                Console.WriteLine("Searching for: " + userId);

                if (users.UserExists(userId))
                {
                    string[]? user = users.GetUser(userId);

                    if (user != null)
                    {
                        string response =
                            $"USER_FOUND|{user[0]}|{user[1]}|Online\n";

                        Console.WriteLine("Sending: " + response);

                        byte[] reply = Encoding.UTF8.GetBytes(response);
                        stream.Write(reply, 0, reply.Length);
                    }
                    else
                    {
                        byte[] reply =
                            Encoding.UTF8.GetBytes("USER_NOT_FOUND\n");

                        stream.Write(reply, 0, reply.Length);
                    }
                }
                else
                {
                    byte[] reply =
                        Encoding.UTF8.GetBytes("USER_NOT_FOUND\n");

                    stream.Write(reply, 0, reply.Length);
                }

                continue;
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

