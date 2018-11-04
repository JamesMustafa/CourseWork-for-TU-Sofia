using System;
using System.Threading;

namespace CourseWork
{
    public class WrongAnswers
    {
        public void BigMethod(int k)
        {
            switch(k)
            {
                case 5:
                    {
                        for (int i = 11; i < 17; i++)
                        {
                            Console.SetCursorPosition(50, i);
                            Thread.Sleep(50);
                            Console.Write("§");
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 50; i < 60; i++)
                        {
                            Console.SetCursorPosition(i, 10);
                            Thread.Sleep(50);
                            Console.Write("=");
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 11; i < 13; i++)
                        {
                            Console.SetCursorPosition(55, i);
                            Thread.Sleep(50);
                            Console.WriteLine("|");
                            i++;
                            Console.SetCursorPosition(55, i);
                            Console.Write("O");
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 14; i < 15; i++)
                        {
                            Console.SetCursorPosition(54, 13);
                            Console.Write("/");
                            Thread.Sleep(500);
                            Console.SetCursorPosition(55, 13);
                            Console.Write("|");
                            Thread.Sleep(500);
                            Console.SetCursorPosition(56, 13);
                            Console.Write("\\");
                            Thread.Sleep(500);

                        }
                        break;
                    }
                case 1:
                    {
                        for (int i = 10; i < 11; i++)
                        {
                            Console.SetCursorPosition(55, 14);
                            Console.Write("|");
                            Thread.Sleep(500);
                            Console.SetCursorPosition(54, 15);
                            Console.Write("/");
                            Thread.Sleep(500);
                            Console.SetCursorPosition(56, 15);
                            Console.Write("\\");

                        }
                        break;
                    }


            }
        }
          
          
    }
}
