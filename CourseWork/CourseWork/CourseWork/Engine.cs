using System;
using System.Threading;
using System.Collections.Generic;

namespace CourseWork
{
    public class Engine
    {
        //----Инициализиране на конзолата----
        public const int WordRow = 3;
        public int WordPlace = Console.WindowWidth / 2;
        //----Инициализиране на класове----
        public Level Level;
        public Cheat cheat;
        public WrongAnswers wrongAnswers;
        public Random Random;
        public IUserInterface UserInterface;
        //----Инициализиране на променливи----
        public int NoValueCounter;
        public int SpaceCounter;
        public int cheatIndexer;
        public int RandomNumber { get; set; }
        public int Indexer1 { get; set; }
        public int Indexer2 { get; set; }
        public int PointCounter { get; set; }
        public string Word { get; set; }
        public int CheatNumber { get; set; }
        public char[] NewWord { get; set; }
        public string Letter { get; set; }
        public char charLetter { get; set; }
        public char[] RealWord { get; set; }
        public bool IsThereWord;
        public int WrongCounter;
        public List<int> RandomController;
        public int WrongAnswersForView;
        public int counter;

        public Engine(Level level, IUserInterface userInterface)
        {
            this.Level = level;
            this.UserInterface = userInterface;
            this.Random = new Random();
            this.RandomNumber = Random.Next(0, Level.TheWordsArray.Length - 1);
            this.Word = this.Level.TheWordsArray[this.RandomNumber];
            this.NewWord = new char[] { };
            this.RealWord = new char[] { };
            this.CheatNumber = this.Level.CheatNumber;
            this.wrongAnswers = new WrongAnswers();
            this.RealWord = this.Word.ToCharArray();
            this.RandomController = new List<int>();
            this.RandomController.Add(RandomNumber);
            this.cheat = new Cheat(this);
            this.NoValueCounter = 0;
            this.SpaceCounter = 0;
            this.cheatIndexer = 0;
            this.IsThereWord = false;
            this.WrongCounter = 5;
            this.WrongAnswersForView = 4;
            this.counter = 0;
            this.PointCounter = 0;
        }

        public void WordPut() //метод, който служи за обратна връзка с играча.
        {                     //Взима буквата която е подал и е изпраща към безкрайния игрови цикъл
                              //Ако е жокер го преработва с метод от друг клас.
            Console.SetCursorPosition(10, 3);
            Console.Write("Моля въведете вашата буква:");
            this.Letter = Console.ReadLine();
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("(За жокер натиснете 1)");
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("(За изход натиснете 2)");

            if (this.Letter == "1")
            {
                if (CheatNumber > 0)
                {
                    this.Letter = this.cheat.OnCheat();
                }
                else
                {
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine("Вие нямате право на жокер !!!");
                }
            }
            if (this.Letter == "2")
            {
                this.Exit();
            }
        }

        public void Exit() //излиза от играта чрез exception.
        {
            this.Level.ExceptionButton();
        }

        public void OnWrongAnswer()
        {
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("Въведохте грешна буква. Остават ви още {0} опити", WrongAnswersForView);
            WrongAnswersForView--;
            this.wrongAnswers.BigMethod(WrongCounter); //метод който е взет от друг клас и рисува
            WrongCounter--;                            //бесеница с "for" цикли
            if (WrongCounter == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Играта свърши !!!");
                Console.WriteLine("Думата е {0}", this.Word);
                Thread.Sleep(1000);
                this.Exit();
            }
        }
        //проверява дали новата ни дума е била използвана и
        //я изобразява ако не е.
        public void NewWordMaker() //връща всички стойности и подава нова дума
        {
            for (int i = 0; i < 1; i++)
            {
                do
                {
                    RandomNumber = Random.Next(0, Level.TheWordsArray.Length - 1);
                }
                while (RandomController.Contains(RandomNumber));
                RandomController.Add(RandomNumber);
            }
            this.Word = this.Level.TheWordsArray[this.RandomNumber];
            this.RealWord = this.Word.ToCharArray();
            this.Level.IsFilled = false;
            this.WrongCounter = 5;
            this.IsThereWord = false;
            this.SpaceCounter = 0;
            this.WrongAnswersForView = 4;
        }

        public void AnotherControl()
        {
            if (NoValueCounter > -1)
            {

                for (int i = 1; i < NewWord.Length-1; i++)
                {
                    if(Letter.Equals((Word[i].ToString()), StringComparison.OrdinalIgnoreCase) && NewWord[i] == '_') // замества буквите по местата им
                    {
                        NewWord[i] = Word[i];
                        NoValueCounter--;
                    }
                    else if (Letter.Equals((Word[i].ToString()), StringComparison.OrdinalIgnoreCase) && NewWord[i] != '_') //ако вече сме пробвали тази буква ни дава грешка
                    {
                        this.OnWrongAnswer();
                        break;
                    }
                    else if(Letter.Equals((Word[0].ToString()),StringComparison.OrdinalIgnoreCase) && NewWord[i] != '_') //ако въведем първата буква от думата и я няма на никоя друга ПРАЗНА позиция ни дава грешка
                    {
                        if(Word.LastIndexOf(Char.Parse(Letter)) == 0)
                        {
                            this.OnWrongAnswer();
                            break;
                        }
                    }
                    else if (Letter.Equals((Word[Word.Length-1].ToString()), StringComparison.OrdinalIgnoreCase) && NewWord[i] != '_') //ако въведем последната буква от думата и я няма на никоя друга ПРАЗНА позиция ни дава грешка
                    {
                        if(Word.IndexOf(Char.Parse(Letter)) == Word.Length-1)
                        {
                            this.OnWrongAnswer();
                            break;
                        }
                    }
                }
            }
        }

        public void RenderWord() //метод за изобразяване на конзолата.
        {

            Console.SetCursorPosition(Console.WindowWidth / 2, 2);

            foreach (var item in NewWord)
            {
                Console.Write(item);
            }

        }
        public void RenderPoints() //изобразява точките на играча
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);
            Console.WriteLine("Точки: {0}",this.PointCounter);
        }

        public void MakeWordDifficult()
        {
            NewWord = RealWord;
            for (int i = 1; i < RealWord.Length-1; i++)
            {
              //  NewWord[i] = NewWord[i] == ' ' ? ' ' : '_'; //simplified

                if (NewWord[i] == ' ') //if there is space between the words (ex: Червен бряг),
                {                      //it keeps the space symbol without putting '_' to it !
                    NewWord[i] = ' ';
                    SpaceCounter++;
                }
                else
                {
                    NewWord[i] = '_';
                }

            }
            NoValueCounter = (RealWord.Length - 3) - SpaceCounter; //Counter for '_' symbol
        }

       public void Run()
        {
            while (true)
            {

                if (IsThereWord == false) //ако няма изписана дума я създава и я показва на конзолата
                {
                    this.MakeWordDifficult();
                    RenderWord();
                    RenderPoints();
                    this.IsThereWord = true;
                }
                Thread.Sleep(50);

                if (Level.IsFilled == false) //докато думата не е попълнена
                {
                    this.WordPut();
                    if (this.Word.Contains(this.Letter) || this.Word.Contains(this.Letter.ToUpper())) //проверява дали дадената буква я има
                    {
                        AnotherControl(); // проверка
                        this.RenderWord();       //рисува думата на конзолата
                        this.RenderPoints();
                        this.cheat.Counter = 0;

                        if (NoValueCounter < 0) //ако думата е попълнена
                        {
                            Thread.Sleep(1000); 
                            this.Level.IsFilled = true;
                            Console.Clear();
                        }

                    }
                    else if(this.Letter != "1" || this.Letter == "2") //проверка дали буквата се съдържа
                    {                                                 //в думата и ако я няма, и също така
                        this.OnWrongAnswer();                         //е различна от 1 или 2, ни дава грешен отговор.
                    }
                }
                else
                {
                    this.PointCounter++; //увеличава точките на играча
                    this.NewWordMaker(); //метод който създава нова дума
                }
            }
        }
    }
}
