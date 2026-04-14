// Client.cs
// TCP Client that sends commands to the server and displays responses

using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {
            using TcpClient client = new TcpClient("127.0.0.1", 5000);
            using NetworkStream stream = client.GetStream();

            Console.WriteLine("Connected to server.");
            Console.WriteLine("Available commands:");
            Console.WriteLine("TIME");
            Console.WriteLine("UPPER your_text");
            Console.WriteLine("LOWER your_text");
            Console.WriteLine("FILE");
            Console.WriteLine("Type 'exit' to quit\n");

            while (true)
            {
                Console.Write("Enter command: ");
                string? message = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(message))
                    continue;

                if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                // Send message to server
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // Receive response
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Server response: " + response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}