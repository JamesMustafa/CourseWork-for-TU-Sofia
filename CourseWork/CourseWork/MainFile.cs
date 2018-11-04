using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;

namespace CourseWork
{
    public class MainClass
    {

        public static void Main()
        {
            Console.WriteLine("Моля въведете нивото на трудност(Лесно,Средно,Трудно): ");
            string levelString = Console.ReadLine();
            Level level = new LevelEasy();
            List<string> difficuly = new List<string>
            {
                "лесно",
                "Лесно",
                "средно",
                "Средно",
                "трудно",
                "Трудно"
            };

            foreach (var diff in difficuly)
            {
                if (difficuly.Contains(levelString) == false)
                {
                    Console.Write("Грешка!!! Моля опитайте отново: ");
                    levelString = Console.ReadLine();
                }
                else
                {
                    Console.Clear();

                    if (levelString == "лесно")
                    {
                        levelString = "Лесно";
                    }
                    if (levelString == "средно")
                    {
                        levelString = "Средно";
                    }
                    if (levelString == "трудно")
                    {
                        levelString = "Трудно";
                    }

                }
            }

            switch (levelString)
            {
                case "Лесно":
                    {
                        level = new LevelEasy();
                        break;
                    }
                case "Средно":
                    {
                        level = new LevelNormal();
                        break;
                    }
                case "Трудно":
                    {
                        level = new LevelHard();
                        break;
                    }
            }
            IUserInterface keyboard = new KeyboardInterface();
            Engine engine = new Engine(level, keyboard);
            engine.Run();

            //излишно
            /*   keyboard.OnCheatPressed += (object sender, EventArgs eventArgs) =>
               {
                   engine.OnCheat();
               };
               keyboard.OnExitPressed += (sender, e) => engine.Exit(); */
        }
    }
}