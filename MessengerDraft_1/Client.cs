using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public class Client
{
    private TcpClient? client;
    private NetworkStream? stream;
    private StreamReader? reader;
    private bool listening = false;

    public event Action<string>? MessageReceived;

    public void Connect()
    {
        try
        {
            client = new TcpClient();

            Console.WriteLine("Connecting to server...");

            client.Connect("100.122.189.41", 5000);

            stream = client.GetStream();
            reader = new StreamReader(stream, Encoding.UTF8);

            Console.WriteLine("CONNECTED TO SERVER");
            Console.WriteLine("Client object: " + this);
        }
        catch (Exception ex)
        {
            Console.WriteLine("CONNECTION ERROR: " + ex.Message);
            MessageBox.Show("Connection error: " + ex.Message);
        }
    }

    public void Send(string message)
    {
        try
        {
            if (stream == null)
            {
                MessageBox.Show("Stream is null. Client is not connected.");
                return;
            }

            message += "\n";

            byte[] data = Encoding.UTF8.GetBytes(message);

            stream.Write(data, 0, data.Length);
            stream.Flush();

            Console.WriteLine("SENT: " + message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("SEND ERROR: " + ex.Message);
            MessageBox.Show("Send error: " + ex.Message);
        }
    }

    public string ReceiveMessage()
    {
        try
        {
            if (reader == null)
                return "";

            string? message = reader.ReadLine();

            if (message == null)
                return "";

            Console.WriteLine("RECEIVED: " + message);

            return message;
        }
        catch (Exception ex)
        {
            Console.WriteLine("RECEIVE ERROR: " + ex.Message);
            return "";
        }
    }

    public void StartListening()
    {
        if (listening)
            return;

        if (reader == null)
        {
            Console.WriteLine("Cannot start listener: reader is null.");
            return;
        }

        listening = true;

        Thread thread = new Thread(() =>
        {
            Console.WriteLine("LISTENER STARTED");

            while (listening)
            {
                string message = ReceiveMessage();

                if (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("Listener stopped: no message received.");
                    break;
                }

                MessageReceived?.Invoke(message);
            }

            listening = false;

            Console.WriteLine("LISTENER STOPPED");
        });

        thread.IsBackground = true;
        thread.Start();
    }

    public bool IsConnected
    {
        get
        {
            return client != null &&
                   stream != null;
        }
    }

    public void deleteMessage(string messageId)
    {
        Send($"DELETE_MESSAGE:{messageId}");
    }

    public void Disconnect()
    {
        listening = false;

        try
        {
            reader?.Close();
            stream?.Close();
            client?.Close();
        }
        catch
        {
        }

        reader = null;
        stream = null;
        client = null;

        Console.WriteLine("CLIENT DISCONNECTED");
    }
}