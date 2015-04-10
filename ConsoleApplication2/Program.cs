using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        public static Thread Driving = new Thread(Variables.LaneChange);
        public static Thread EndGame = new Thread(Variables.End);
        //public static Thread RoadThread=new Thread();
        static void Main()
        {
            Variables.Copy(Variables.Old, Variables.GeneralMatrix);
            Variables.MenuGame();
            if (Variables.Menu == 4)
            {
                Variables.ServerClient = false;
                IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                IPAddress ipAddr = ipHost.AddressList[1];
                var ipEndPoint = new IPEndPoint(ipAddr, 11000);
                var sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                Variables.GamePlay();
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                Socket handler = sListener.Accept();
                var bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                Console.WriteLine("\nКлиент набрал {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
                // Отправляем ответ клиенту
                string reply = Convert.ToString(Variables.TaktsMax);
                byte[] msg = Encoding.UTF8.GetBytes(reply);
                handler.Send(msg);
                Console.ReadKey();
            }
            if (Variables.Menu == 5)
            {
                var bytes = new byte[1000];
                Variables.ServerClient = true;
                IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                IPAddress ipAddr = ipHost.AddressList[1];
                var ipEndPoint = new IPEndPoint(ipAddr, 11000);
                var sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ipEndPoint);
                Variables.GamePlay();
                byte[] msg = Encoding.UTF8.GetBytes(Convert.ToString(Variables.TaktsMax));

                // Отправляем данные через сокет
                sender.Send(msg);
                Console.WriteLine("Ожидаем ответ от сервера");
                // Получаем ответ от сервера
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine("\nСервер набрал {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                Console.ReadKey();
            }
            if (Variables.Menu == 1)
            {
                Variables.GamePlay();
                Variables.ServerGenerate.Abort();
            }


        }


    }
}
