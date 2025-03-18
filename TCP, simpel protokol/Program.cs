using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Linq;
using TCP__simpel_protokol;

public class Program
{
    private static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 7);
        listener.Start();
        Console.WriteLine("Server is listening on port 7...");
        while (true)
        {
            TcpClient socket = listener.AcceptTcpClient();
            Console.WriteLine("Client connected.");
            Task.Run(() => ClientHandler.HandleClient(socket));
        }
    }

}
