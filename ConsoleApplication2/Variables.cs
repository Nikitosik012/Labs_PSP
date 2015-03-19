using System;
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
        { { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 2, 2, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 2, 2, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0 }};

        private static int _shift; //Смещение
        /// <summary>
        /// Флаг говорящий о положении машинки
        /// </summary>
        /// True-левый False-правый
        public static bool Key;
        /// <summary>
        /// Время одного такта игры
        /// </summary>
        public static int Time = 200;
        /// <summary>
        /// Отсчет 7и тактов
        /// </summary>
        public static int Takts = 0;
        /// <summary>
        /// Количество тактов за всю игру
        /// </summary>
        public static int TaktsMax = 0;
        /// <summary>
        /// Переменная сообщающая о поражении
        /// </summary>
        public static bool Error;
        /// <summary>
        /// Семафор для корректной игры
        /// </summary>
        public static Semaphore HSemaphore = new Semaphore(1, 1);
        /// <summary>
        /// Событие требующее зарытия потока
        /// </summary>
        public static AutoResetEvent ResetEvent1 = new AutoResetEvent(false);
        /// <summary>
        /// Рисование
        /// </summary>
        public static void Output()
        {
            Console.Clear();
            for (int i = 0; i < GeneralMatrix.GetLength(0); i++)
            {
                Console.Write("                             ");
                for (int j = 0; j < GeneralMatrix.GetLength(1); j++)
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
            for (int i = _shift; i < GeneralMatrix.GetLength(0); i = i + 2)
            {
                if (_shift == 1)
                {
                    GeneralMatrix[0, 0] = 0;
                    GeneralMatrix[0, 7] = 0;
                    GeneralMatrix[0, 14] = 0;
                }
                GeneralMatrix[i, 0] = 1;
                GeneralMatrix[i, 7] = 1;
                GeneralMatrix[i, 14] = 1;
                if (i == GeneralMatrix.GetLength(0) - 1) continue;
                GeneralMatrix[i + 1, 0] = 0;
                GeneralMatrix[i + 1, 7] = 0;
                GeneralMatrix[i + 1, 14] = 0;
            }
            for (int i = GeneralMatrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = GeneralMatrix.GetLength(1) - 1; j >= 0; j--)
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
                if (key1.Key == ConsoleKey.LeftArrow && !Key)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 2] = 2;
                        GeneralMatrix[i, 3] = 2;
                        GeneralMatrix[i, 4] = 2;
                        GeneralMatrix[i, 10] = 0;
                        GeneralMatrix[i, 11] = 0;
                        GeneralMatrix[i, 12] = 0;
                        if (GeneralMatrix[i, 1] == 8)
                        {
                            //ResetEvent1.Set();
                            Error = true;
                        }
                    }
                    Key = true;
                }
                if (key1.Key == ConsoleKey.RightArrow && Key)
                {
                    for (var i = 20; i < GeneralMatrix.GetLength(0); i++)
                    {
                        GeneralMatrix[i, 2] = 0;
                        GeneralMatrix[i, 3] = 0;
                        GeneralMatrix[i, 4] = 0;
                        GeneralMatrix[i, 10] = 2;
                        GeneralMatrix[i, 11] = 2;
                        GeneralMatrix[i, 12] = 2;
                        if (GeneralMatrix[i, 13] == 8)
                        {
                            //ResetEvent1.Set();
                            Error = true;
                        }
                    }
                    Key = false;
                }
                HSemaphore.WaitOne();
                Output();
                HSemaphore.Release();
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
        }
        /// <summary>
        /// Преднамеренно выходит из потока
        /// </summary>
        public static void End()
        {
            ResetEvent1.WaitOne();
            Program.Driving.Abort();
        }
    }
}