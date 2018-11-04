using System;
namespace CourseWork
{
    public class Cheat
    {
        public Engine Engine;
        public string OurWord;
        public int CheatNumber;
        char FullCharLetter;
        string FullStringLetter;
        public int Counter;
        public int FirstFoundIndexer;
        public char[] EditedWord;
        public Cheat(Engine engine)
        {
            this.Engine = engine;
            this.CheatNumber = engine.CheatNumber;
            this.OurWord = engine.Word;
            this.EditedWord = engine.NewWord;
            this.Counter = 0;
        }

        public string OnCheat(char[] SomeEditedWord)
        {
            if (this.CheatNumber > 0)
            {
                Console.SetCursorPosition(10, 6);
                Console.WriteLine("Остават Ви още {0} жокера", CheatNumber);
                for (int i = 0; i < SomeEditedWord.Length - 1; i++)
                {
                    if (SomeEditedWord[i] == '_' && Counter == 0)
                    {
                        FirstFoundIndexer = i;
                        Counter = 1;

                    }
                }
                FullCharLetter = OurWord[FirstFoundIndexer];
                FullStringLetter = this.FullCharLetter.ToString();
                this.CheatNumber--;

            }
            else
            {
                Console.SetCursorPosition(10, 8);
                Console.WriteLine("Вие нямате право на жокер !!!");
                FullStringLetter = "_"; 
            }
            return FullStringLetter;
        }

    }
}
