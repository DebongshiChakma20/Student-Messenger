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
            if (client != null && client.Connected) return;

            client = new TcpClient();

            client.Connect("100.122.189.41", 5000);

            stream = client.GetStream();
            reader=new StreamReader(stream,Encoding.UTF8);
            
        }
        catch (Exception ex)
        {
            MessageBox.Show("Connection error: " + ex.Message);
        }
    }

    public void Send(string message)
    {
        try
        {
            if (client == null || stream == null || !client.Connected)
            {
                MessageBox.Show("Client is NOT connected.");
                return;
            }
            message += "\n";
            byte[] data = Encoding.UTF8.GetBytes(message);

            stream.Write(data, 0, data.Length);
            stream.Flush();

            Console.WriteLine("Sent: " + message);
        }
        catch (Exception ex)
        {
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

            Console.WriteLine("Client received: " + message);

            return message;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Receive error: " + ex.Message);
            return "";
        }
    }

    public void deleteMessage(string messageId)
    {
        string request = $"DELETE_MESSAGE:{messageId}";

        Send(request);
    }

    public void StartListening()
    {
        if (listening)
            return;

        listening = true;

        Thread thread = new Thread(() =>
        {
            while (listening && client != null && client.Connected)
            {
                string message = ReceiveMessage();

                if (!string.IsNullOrEmpty(message))
                {
                    MessageReceived?.Invoke(message);
                }
            }

            listening = false;
        });

        thread.IsBackground = true;
        thread.Start();
    }

    public void Disconnect()
    {
        listening = false;

        try
        {
            stream?.Close();
            client?.Close();
        }
        catch
        {
        }

        stream = null;
        client = null;
    }
}