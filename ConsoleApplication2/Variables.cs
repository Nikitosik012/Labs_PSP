using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApplication2
{
    /// <summary>
    /// Класс содержащий все методы и переменные
    /// </summary>
    class Variables
    {
        /// <summary>
        /// Матрица поля
        /// </summary>
        public static int[,] GeneralMatrix = 
        { { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 6, 6, 6, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 6, 6, 6, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

        public static Semaphore SemaphoreBuffer = new Semaphore(1, 1);
        /// <summary>
        /// Список хранящий последовательность препядствий
        /// </summary>
        public static List<int> RoadToHell = new List<int>();
        /// <summary>
        /// Буфер хранящий поле
        /// </summary>
        public static List<int[,]> Buffer = new List<int[,]>();
        public static Thread AddBuffer = new Thread(AddBufferMethod);
        public static Thread OutBuffer = new Thread(OutBufferMethod);
        public static int[,] Old = new int[GeneralMatrix.GetLength(0), GeneralMatrix.GetLength(1)];
        private static int _shift; //Смещение

        /// <summary>
        /// Флаг говорящий о положении машинки
        /// </summary>
        /// True-левый False-правый
        public static int Key = 2;
        /// <summary>
        /// Время одного такта игры
        /// </summary>
        public static int Time = 100;
        /// <summary>
        /// Отсчет 7и тактов
        /// </summary>
        public static int Takts;
        /// <summary>
        /// Количество тактов за всю игру
        /// </summary>
        public static int TaktsMax;
        /// <summary>
        /// Оповецение о том что больше карта обновляться не будет
        /// </summary>
        public static bool Panic;
        /// <summary>
        /// Переменная сообщающая о поражении
        /// </summary>
        public static bool Error;
        /// <summary>
        /// Переменная для меню
        /// </summary>
        public static int Menu = 1;
        /// <summary>
        /// Переменная определяющая(см название) false - server, true - client
        /// </summary>
        public static bool ServerClient;
        /// <summary>
        /// Семафор для корректной игры
        /// </summary>
        public static Semaphore HSemaphore = new Semaphore(1, 1);
        /// <summary>
        /// Событие требующее зарытия потока
        /// </summary>
        public static AutoResetEvent ResetEvent1 = new AutoResetEvent(false);
        public static AutoResetEvent ResetEvent2 = new AutoResetEvent(false);
        /// <summary>
        /// Рисование
        /// </summary>
        public static void Output()
        {
            Console.Clear();
            for (var i = 0; i < GeneralMatrix.GetLength(0); i++)
            {
                Console.Write("                             ");
                for (var j = 0; j < GeneralMatrix.GetLength(1); j++)
                {
                    if (GeneralMatrix[i, j] != 0)
                    {
                        if (GeneralMatrix[i, j] == 8)
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(GeneralMatrix[i, j]);
                        Console.ResetColor();
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Движение
        /// </summary>
        public static void Motion()
        {
            _shift = GeneralMatrix[0, 0] == 0 ? 0 : 1;
            for (var i = _shift; i < GeneralMatrix.GetLength(0); i = i + 2)
            {
                if (_shift == 1)
                {
                    GeneralMatrix[0, 0] = 0;
                    GeneralMatrix[0, 7] = 0;
                    GeneralMatrix[0, 14] = 0;
                    GeneralMatrix[0, 21] = 0;
                    GeneralMatrix[0, 28] = 0;
                }
                GeneralMatrix[i, 0] = 1;
                GeneralMatrix[i, 7] = 1;
                GeneralMatrix[i, 14] = 1;
                GeneralMatrix[i, 21] = 1;
                GeneralMatrix[i, 28] = 1;
                if (i == GeneralMatrix.GetLength(0) - 1) continue;
                GeneralMatrix[i + 1, 0] = 0;
                GeneralMatrix[i + 1, 7] = 0;
                GeneralMatrix[i + 1, 14] = 0;
                GeneralMatrix[i + 1, 21] = 0;
                GeneralMatrix[i + 1, 28] = 0;
            }
            for (var i = GeneralMatrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (var j = GeneralMatrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if (GeneralMatrix[i, j] == 8)
                    {
                        GeneralMatrix[i, j] = 0;
                        if (i != GeneralMatrix.GetLength(0) - 1)
                        {
                            if (GeneralMatrix[i + 1, j] == 2)
                            {
                                ResetEvent1.Set();
                                Error = true;
                            }
                            GeneralMatrix[i + 1, j] = 8;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Метод реализовывающий смену полосы по которой едет машинка
        /// </summary>
        public static void LaneChange()
        {
            while (true)
            {
                var key1 = Console.ReadKey(true);

                if (key1.Key == ConsoleKey.LeftArrow && Key == 2)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 2] = 6;
                        GeneralMatrix[i, 3] = 6;
                        GeneralMatrix[i, 4] = 6;
                        GeneralMatrix[i, 10] = 0;
                        GeneralMatrix[i, 11] = 0;
                        GeneralMatrix[i, 12] = 0;
                        if (GeneralMatrix[i, 1] == 8)
                        {
                            Error = true;
                        }
                    }
                    Key--;
                }
                else if (key1.Key == ConsoleKey.LeftArrow && Key == 3)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 16] = 0;
                        GeneralMatrix[i, 17] = 0;
                        GeneralMatrix[i, 18] = 0;
                        GeneralMatrix[i, 10] = 6;
                        GeneralMatrix[i, 11] = 6;
                        GeneralMatrix[i, 12] = 6;
                        if (GeneralMatrix[i, 9] == 8)
                        {
                            Error = true;
                        }
                    }
                    Key--;
                }
                else if (key1.Key == ConsoleKey.LeftArrow && Key == 4)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 16] = 6;
                        GeneralMatrix[i, 17] = 6;
                        GeneralMatrix[i, 18] = 6;
                        GeneralMatrix[i, 22] = 0;
                        GeneralMatrix[i, 23] = 0;
                        GeneralMatrix[i, 24] = 0;
                        if (GeneralMatrix[i, 15] == 8)
                        {
                            Error = true;
                        }
                    }
                    Key--;
                }
                else if (key1.Key == ConsoleKey.RightArrow && Key == 3)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 16] = 0;
                        GeneralMatrix[i, 17] = 0;
                        GeneralMatrix[i, 18] = 0;
                        GeneralMatrix[i, 23] = 6;
                        GeneralMatrix[i, 24] = 6;
                        GeneralMatrix[i, 25] = 6;
                        if (GeneralMatrix[i, 25] == 8)
                        {
                            Error = true;
                        }
                    }
                    Key++;
                }
                else if (key1.Key == ConsoleKey.RightArrow && Key == 2)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 16] = 6;
                        GeneralMatrix[i, 17] = 6;
                        GeneralMatrix[i, 18] = 6;
                        GeneralMatrix[i, 10] = 0;
                        GeneralMatrix[i, 11] = 0;
                        GeneralMatrix[i, 12] = 0;
                        if (GeneralMatrix[i, 17] == 8)
                        {
                            Error = true;
                        }
                    }
                    Key++;
                }
                else if (key1.Key == ConsoleKey.RightArrow && Key == 1)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 2] = 0;
                        GeneralMatrix[i, 3] = 0;
                        GeneralMatrix[i, 4] = 0;
                        GeneralMatrix[i, 10] = 6;
                        GeneralMatrix[i, 11] = 6;
                        GeneralMatrix[i, 12] = 6;
                        if (GeneralMatrix[i, 13] == 8)
                        {
                            Error = true;
                        }
                    }
                    Key++;
                }
                if (Error)
                    break;
            }
        }
        /// <summary>
        /// Метод вызывающий препядствие
        /// </summary>
        public static void Obstacle()
        {
            //1-лево 2-право
            var rand = new Random();
            var a = rand.Next(1, 3);
            if (a == 1)
            {
                for (var i = 1; i < 7; i++)
                {
                    GeneralMatrix[0, i] = 8;
                }
            }
            else
            {
                for (var i = 8; i < 14; i++)
                {
                    GeneralMatrix[0, i] = 8;
                }
            }
            RoadToHell.Add(a);
        }
        /// <summary>
        /// Преднамеренно выходит из потока
        /// </summary>
        public static void End()
        {
            ResetEvent1.WaitOne();
            Program.Driving.Abort();
            AddBuffer.Abort();
            Panic = true;
        }
        /// <summary>
        /// Меню игры (появляется 1 раз)
        /// </summary>
        public static void MenuGame()
        {
            while (true)
            {
                Console.Clear();
                MenuMethod(1);
                Console.WriteLine("\n\n\n\n\n\n\n\n\n                               Single player");
                Console.ResetColor();
                MenuMethod(2);
                Console.WriteLine("                               Multiplayer");
                Console.ResetColor();
                MenuMethod(3);
                Console.WriteLine("                               Exit");
                Console.ResetColor();
                var key1 = Console.ReadKey(true);
                if (key1.Key == ConsoleKey.DownArrow && Menu != 3)
                {
                    Menu++;
                }
                if (key1.Key == ConsoleKey.UpArrow && Menu != 0)
                {
                    Menu--;
                }
                if (key1.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            if (Menu == 2)
            {
                Menu = 4;
                while (true)
                {
                    Console.Clear();
                    MenuMethod(4);
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n                               Server");
                    Console.ResetColor();
                    MenuMethod(5);
                    Console.WriteLine("                               Client");
                    Console.ResetColor();
                    var key1 = Console.ReadKey(true);
                    if (key1.Key == ConsoleKey.DownArrow && Menu != 5)
                    {
                        Menu++;
                    }
                    if (key1.Key == ConsoleKey.UpArrow && Menu != 4)
                    {
                        Menu--;
                    }
                    if (key1.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Метод подкрашиваюший выбранный пункт меню
        /// </summary>
        /// <param name="n"></param>
        public static void MenuMethod(int n)
        {
            if (Menu == n)
                Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        /// <summary>
        /// Геймплей игры
        /// </summary>
        public static void GamePlay()
        {
            Console.Clear();
            Output();
            Program.Driving.Start();
            Program.EndGame.Start();
            AddBuffer.Start();
            OutBuffer.Start();
            while (true)
            {
                if (Error)
                    break;
                Motion();
                Thread.Sleep(Time);
                Takts++;
                TaktsMax++;
                if (Takts != 7) continue;
                Obstacle();
                Takts = 0;
            }
            ResetEvent1.Set();
            ResetEvent2.WaitOne();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 23);
            Console.Write("\n                             Game over " + TaktsMax + " Points\n");
            Console.ReadKey();
        }
        /// <summary>
        /// Метод добавляющий матрицу в буффер
        /// </summary>
        public static void AddBufferMethod()
        {
            while (true)
            {
                SemaphoreBuffer.WaitOne();
                Buffer.Add(GeneralMatrix);
                SemaphoreBuffer.Release();
                Thread.Sleep(10);
            }
        }

        public static void OutBufferMethod()
        {
            while (true)
            {

                if (Buffer.Count > 1)
                {
                    int[,] buf = new int[GeneralMatrix.GetLength(0), GeneralMatrix.GetLength(1)];
                    Copy(buf, Buffer[0]);
                    SemaphoreBuffer.WaitOne();
                    Buffer.Remove(Buffer[0]);
                    SemaphoreBuffer.Release();
                    for (var i = 0; i < buf.GetLength(0); i++)
                    {
                        for (var j = 0; j < buf.GetLength(1); j++)
                        {
                            if (buf[i, j] == 8)
                            {
                                if (buf[i, j] != Old[i, j])
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.SetCursorPosition(j + 29, i);
                                    Console.Write(buf[i, j]);
                                    Console.ResetColor();
                                }
                            }
                            else if (buf[i, j] == 6)
                            {
                                if (buf[i, j] != Old[i, j])
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.SetCursorPosition(j + 29, i);
                                    Console.Write(buf[i, j]);
                                    Console.ResetColor();
                                }
                            }
                            else if (buf[i, j] != 0)
                            {
                                if (buf[i, j] != Old[i, j])
                                {
                                    Console.SetCursorPosition(j + 29, i);
                                    Console.Write(buf[i, j]);
                                }
                            }
                            else if (buf[i, j] != 0)
                            {

                            }
                            else
                            {
                                if (buf[i, j] != Old[i, j])
                                {
                                    Console.SetCursorPosition(j + 29, i);
                                    Console.Write(" ");
                                }
                            }
                        }
                    }
                    Copy(Old, buf);
                }
                if (Panic)
                {

                    ResetEvent2.Set();
                    break;
                }
                Thread.Sleep(25);
            }
        }

        public static void Copy(int[,] one, int[,] two)
        {
            for (int i = 0; i < one.GetLength(0); i++)
                for (int j = 0; j < one.GetLength(1); j++)
                    one[i, j] = two[i, j];
        }
    }
}