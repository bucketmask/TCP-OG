using System;
using System.Net.Sockets;
using System.Text;
using System.IO;


namespace TCPClientForCsharp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                //connects to client
                TcpClient client = new TcpClient("127.0.0.1", 9999);
                string msg = "Hello There";

                //buffers the msg to be sent
                int byteCount = Encoding.ASCII.GetByteCount(msg + 1);
                Byte[] DataToSend = new Byte[byteCount];
                DataToSend = Encoding.ASCII.GetBytes(msg);

                //sends data(msg)
                NetworkStream stream = client.GetStream();
                stream.Write(DataToSend, 0, DataToSend.Length);
                Console.WriteLine("[*] Sent Data: " + msg);

                //waits for response
                StreamReader sr = new StreamReader(stream);
                string response = sr.ReadLine();
                Console.WriteLine(response);

                //closes connection
                stream.Close();
                client.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("didnt work");
            }

        }
    }
}