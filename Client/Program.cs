using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
        connection:
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1300);
                string messageToSend = "If you see this message then you are pretty cool! (^_-)";

                //message into bytes
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                byte[] sendData = new byte[byteCount];
                sendData = Encoding.ASCII.GetBytes(messageToSend);

                //send message
                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                Console.WriteLine("sending data to server...");

                //get response
                StreamReader sr = new StreamReader(stream);
                string response = sr.ReadLine();
                Console.WriteLine(response);

                stream.Close();
                client.Close();
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("failed to connect...");
                goto connection;
            }
        }
    }
}


