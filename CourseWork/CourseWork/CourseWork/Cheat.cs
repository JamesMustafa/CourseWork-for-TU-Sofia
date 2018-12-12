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
            this.CheatNumber = engine.CheatNumber-1;
            this.OurWord = engine.Word;
            this.EditedWord = engine.NewWord;
            this.Counter = 0;
        }

        public string OnCheat()             //Чрез този метод с цикъл намираме на кой индекс се намира
                                            //първата празна буква,виждаме стойността и от пълната дума
                                            //и връщаме буквата която липсва.
        {
            Console.SetCursorPosition(10, 6);
                Console.WriteLine("Остават Ви още {0} жокера", CheatNumber);
                for (int i = 0; i < Engine.NewWord.Length - 1; i++) 
                {
                    if (Engine.NewWord[i] == '_' && Counter == 0)
                    {
                        FirstFoundIndexer = i;
                        Counter = 1;

                    }
                }
                FullCharLetter = Engine.Word[FirstFoundIndexer];
                FullStringLetter = this.FullCharLetter.ToString();
                this.CheatNumber--;
                Engine.CheatNumber--;
                return FullStringLetter;
        }

    }
}
