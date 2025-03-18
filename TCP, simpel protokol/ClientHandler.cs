using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP__simpel_protokol
{
    public static class ClientHandler
    {
        public static void HandleClient(TcpClient socket)
        {
            // Get the network stream to read/write data
            NetworkStream stream = socket.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            while (true) // Keep handling client requests indefinitely
            {
                string message = reader.ReadLine();

                switch (message)
                {
                    case "Random":
                        writer.WriteLine("Input numbers");
                        writer.Flush();

                        string[] twoNumbers = reader.ReadLine().Split();
                        Random random = new Random();
                        int num1 = int.Parse(twoNumbers[0]);
                        int num2 = int.Parse(twoNumbers[1]);
                        string result = random.Next(num1, num2 + 1).ToString();
                        writer.WriteLine(result);
                        writer.Flush();
                        break;

                    case "Add":
                        writer.WriteLine("Input numbers");
                        writer.Flush();

                        string[] addNum = reader.ReadLine().Split();
                        int addNum1 = int.Parse(addNum[0]);
                        int addNum2 = int.Parse(addNum[1]);
                        string addResult = (addNum1 + addNum2).ToString();
                        writer.WriteLine(addResult);
                        writer.Flush();
                        break;

                    case "Subtract":
                        writer.WriteLine("Input numbers");
                        writer.Flush();

                        string[] subNumbers = reader.ReadLine().Split();
                        int subNum1 = int.Parse(subNumbers[0]);
                        int subNum2 = int.Parse(subNumbers[1]);
                        string subResult = (subNum1 - subNum2).ToString();
                        writer.WriteLine(subResult);
                        writer.Flush();
                        break;
                }
                socket.Close();
            }
            
        }
    }
}
