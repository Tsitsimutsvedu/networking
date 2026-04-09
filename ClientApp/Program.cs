// Client.cs
// This program connects to the server and sends user requests.

using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {
            // Connect to server
            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Connected to server.");
            Console.WriteLine("Commands:");
            Console.WriteLine("TIME");
            Console.WriteLine("UPPER your_text");
            Console.WriteLine("LOWER your_text");
            Console.WriteLine("FILE");
            Console.WriteLine("Type 'exit' to quit\n");

            while (true)
            {
                Console.Write("Enter command: ");
                string message = Console.ReadLine();

                if (message.ToLower() == "exit")
                    break;

                // Send request
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // Receive response
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Server response: " + response);
            }

            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
