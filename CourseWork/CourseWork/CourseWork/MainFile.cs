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
            bool isLevelFilled = false;
            Level level = new LevelEasy();

            while (!isLevelFilled)
            {
            
                if (levelString.Equals(("Лесно"), StringComparison.OrdinalIgnoreCase))
                    {
                        level = new LevelEasy();
                        isLevelFilled = true;
                    }
                else if (levelString.Equals(("Средно"), StringComparison.OrdinalIgnoreCase))
                    {
                        level = new LevelNormal();
                        isLevelFilled = true;
                    }
                else if (levelString.Equals(("Трудно"), StringComparison.OrdinalIgnoreCase))
                    {
                        level = new LevelHard();
                        isLevelFilled = true;
                    }
                else
                    {
                        Console.Write("Грешка!!! Моля опитайте отново: ");
                        levelString = Console.ReadLine();
                    }
            }
            Console.Clear();
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