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
        public static Thread EndGame=new Thread(Variables.End);
        static void Main()
        {
            //while (true)
            //{

            //    var key1 = Console.ReadKey(true);
            //    Console.ForegroundColor = ConsoleColor.DarkRed;
            //    Console.WriteLine("                               One player");
            //    Console.ResetColor();
            //    Console.WriteLine("                               Multiplayer");
            //    Console.WriteLine("                               Exit");
            //    Console.ReadKey();
            //}
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 2)
            {
                int n1 = Convert.ToInt32(Console.ReadLine());
                if (n1 == 1)
                {
                    IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                    IPAddress ipAddr = ipHost.AddressList[1];
                    var ipEndPoint = new IPEndPoint(ipAddr, 11000);
                    var sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    sListener.Bind(ipEndPoint);
                    sListener.Listen(10);
                    GamePlay();
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                    Socket handler = sListener.Accept();
                    var bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    Console.WriteLine("\nКлиент набрал набрал {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
                    // Отправляем ответ клиенту
                    string reply = Convert.ToString(Variables.TaktsMax);
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);
                    Console.ReadKey();
                }
                else
                {
                    // Буфер для входящих данных
                    var bytes = new byte[1000000];

                    // Соединяемся с удаленным устройством

                    // Устанавливаем удаленную точку для сокета
                    IPHostEntry ipHost = Dns.GetHostEntry("localhost");

                    IPAddress ipAddr = ipHost.AddressList[1];
                    var ipEndPoint = new IPEndPoint(ipAddr, 11000);
                    var sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    sender.Connect(ipEndPoint);
                    GamePlay();
                    byte[] msg = Encoding.UTF8.GetBytes(Convert.ToString(Variables.TaktsMax));

                    // Отправляем данные через сокет
                    int bytesSent = sender.Send(msg);
                    Console.WriteLine("Ожидаем ответ от сервера");
                    // Получаем ответ от сервера
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("\nСервер набрал {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Console.ReadKey();
                }
            }
            else
            {
                Console.ReadKey();
                GamePlay();
            }

        }

        private static void GamePlay()
        {
            Driving.Start();
            EndGame.Start();
            while (true)
            {
                Variables.HSemaphore.WaitOne();
                if (Variables.Error)
                    break;
                Variables.Output();
                Variables.Motion();
                Variables.HSemaphore.Release();
                Thread.Sleep(Variables.Time);
                Variables.Takts++;
                Variables.TaktsMax++;
                if (Variables.Takts != 7) continue;
                Variables.Obstacle();
                Variables.Takts = 0;
            }
            Variables.ResetEvent1.Set();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                             Game over " + Variables.TaktsMax + " Points\n");
            Console.ReadKey();
        }
    }
}
