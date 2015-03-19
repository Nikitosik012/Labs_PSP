using System;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        public static Thread Driving = new Thread(Variables.LaneChange);
        public static Thread EndGame=new Thread(Variables.End);
        static void Main()
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
            Console.ForegroundColor=ConsoleColor.Red;
            Console.Write("                             Game over " + Variables.TaktsMax + " Points");
            Console.ReadKey();
        }
    }
}
