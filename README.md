Networking Client-Server Application (C# TCP)
📌 Project Overview

This project is a simple client-server networking application built using C# and TCP sockets.
The client sends requests to the server, and the server processes the request and sends a response back.

The system demonstrates basic network communication, command handling, and file reading from a server.

🎯 Selected Module

Networking

🛠️ Technologies Used
C#
.NET Console Application
TCP Sockets (TcpClient & TcpListener)
📁 Project Structure
networking/
│
├── ServerApp/
│   ├── Program.cs      # Server code
│   └── data.txt        # File used by FILE command
│
└── ClientApp/
    └── Program.cs      # Client code
🚀 Features
✔ Client-Server Communication

The client sends a request and the server responds using TCP.

✔ Multiple Request Types Supported

The server can handle the following commands:

TIME → Returns current server date and time
UPPER <text> → Converts text to uppercase
LOWER <text> → Converts text to lowercase
FILE → Reads and returns content from a local file (data.txt)
✔ File Handling

The server reads data from a local text file and sends it to the client.

✔ Error Handling

The server responds with an error message for invalid commands.

▶️ How to Run the Project
1. Start the Server

Open a terminal and run:

cd ServerApp
dotnet run
2. Start the Client

Open a second terminal and run:

cd ClientApp
dotnet run
💬 Example Commands (Client Input)
TIME
UPPER hello world
LOWER HELLO WORLD
FILE
exit
📤 Example Output
Connected to server.

Enter command: TIME
Server response: 2026-04-09 14:30:12

Enter command: UPPER hello
Server response: HELLO

Enter command: FILE
Server response: Hello from C# server file!
📄 data.txt Example
Hello from C# server file!
This file is used in the networking assignment.
🎥 Video Demonstration

📚 What I Learned
How TCP client-server communication works
How to send and receive data over a network
How to process different commands from a client
How to read files from a server in C#
Basic networking concepts in software development

👨‍💻 Author
Tsitsi Mutsvedu

## GitHub Repo
https://github.com/Tsitsimutsvedu/networking