// Server.cs
// TCP Server that handles simple client commands

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        // Create TCP listener on localhost:5000
        TcpListener server = new TcpListener(IPAddress.Loopback, 5000);
        server.Start();

        Console.WriteLine("Server started on port 5000...");
        Console.WriteLine("Waiting for client connection...");

        while (true)
        {
            using TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            using NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            // Read client requests
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                Console.WriteLine($"Received: {request}");

                string response = HandleRequest(request);

                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
            }

            Console.WriteLine("Client disconnected.");
        }
    }

    // Handles all client commands
    static string HandleRequest(string request)
    {
        string[] parts = request.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        string command = parts[0].ToUpper();

        switch (command)
        {
            case "TIME":
                return DateTime.Now.ToString();

            case "UPPER":
                return parts.Length > 1 ? parts[1].ToUpper() : "No text provided";

            case "LOWER":
                return parts.Length > 1 ? parts[1].ToLower() : "No text provided";

            case "FILE":
                try
                {
                    return File.ReadAllText("data.txt");
                }
                catch
                {
                    return "Error reading file or file not found";
                }

            default:
                return "Invalid command. Use TIME, UPPER, LOWER, or FILE.";
        }
    }
}