// Server.cs
// This program creates a TCP server that listens for client requests
// and responds based on different commands.

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        // Create a TCP listener on port 5000
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
        server.Start();

        Console.WriteLine("Server started. Waiting for connection...");

        while (true)
        {
            // Accept client connection
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            // Keep listening for messages
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + request);

                string response = HandleRequest(request);

                byte[] responseData = Encoding.ASCII.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
            }

            client.Close();
            Console.WriteLine("Client disconnected.");
        }
    }

    // Function to process requests
    static string HandleRequest(string request)
    {
        string[] parts = request.Split(' ', 2);
        string command = parts[0].ToUpper();

        // TIME request
        if (command == "TIME")
        {
            return DateTime.Now.ToString();
        }

        // UPPER request
        else if (command == "UPPER")
        {
            if (parts.Length > 1)
                return parts[1].ToUpper();
            else
                return "No text provided";
        }

        // LOWER request
        else if (command == "LOWER")
        {
            if (parts.Length > 1)
                return parts[1].ToLower();
            else
                return "No text provided";
        }

        // FILE request (reads local file)
        else if (command == "FILE")
        {
            try
            {
                return File.ReadAllText("data.txt");
            }
            catch
            {
                return "Error reading file";
            }
        }

        // Invalid request
        else
        {
            return "Invalid command";
        }
    }
}