using System;
using System.Threading;

namespace CourseWork
{
    public class Engine
    {
        public const int WordRow = 3;
        public int counter = 0; 
        public int WordPlace = Console.WindowWidth / 2;
        public Level Level;
        public Cheat cheat;
        public WrongAnswers wrongAnswers;
        public Random Random;
        public int NoValueCounter;
        public int SpaceCounter;
        public int cheatIndexer = 0;
        public IUserInterface UserInterface;
        public int RandomNumber { get; set; }
        public int Indexer1 { get; set; }
        public int Indexer2 { get; set; }
        public int Indexer3 { get; set; }
        public string Word { get; set; }
        public int CheatNumber { get; set; }
        public char[] NewWord { get; set; }
        public string Letter { get; set; }
        public char charLetter { get; set; }
        public char[] RealWord { get; set; }
        public int i = 0;
        public bool IsThereWord;
        public int WrongCounter = 5;
        public int wrongest = 4;


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
            this.cheat = new Cheat(this);
            this.NoValueCounter = 0;
            this.SpaceCounter = 0;
            this.IsThereWord = false;
        }

        public void WordPut()
        {
            Console.SetCursorPosition(10, 3);
            Console.Write("Моля въведете вашата буква:");
            this.Letter = Console.ReadLine();
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("(За жокер натиснете 1)");
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("(За изход натиснете 2)");

    //      if(this.Letter == "1")
    //      {
    //           this.Letter = this.cheat.OnCheat(this.NewWord);
    //      }
            if(this.Letter == "2")
            {
                this.Exit();
            }
            if(this.Letter == "3")
            {
                Console.WriteLine(this.NoValueCounter);
            }
        }

        public void Exit()
        {
            this.Level.ExceptionButton();
        }
        public void NoFirstAndLastLetter()
        {
            if(RealWord[0] != char.Parse(this.Letter) &&
               RealWord[RealWord.Length - 1] != char.Parse(this.Letter))
            {

            }
        }

        public void OnWrongAnswer()
        {
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("Въведохте грешна буква. Остават ви още {0} опити", wrongest);
            wrongest--;
            this.wrongAnswers.BigMethod(WrongCounter);
            WrongCounter--;
            if (WrongCounter == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Играта свърши !!!");
                Console.WriteLine("Думата е {0}", this.Word);
                Thread.Sleep(1000);
                this.Exit();
            }
        }

        public void TwoLettersControl() //прави проверки и ако има две еднакви букви на разл. места,
        {                               //поставя и двете.
            this.Indexer1 = this.Word.IndexOf(Convert.ToChar(this.Letter));
            this.Indexer2 = this.Word.LastIndexOf(Convert.ToChar(this.Letter));

            //-------Проверки за буква само с една позиция -----------

            if (Indexer1 == Indexer2 && Indexer1 != 0 && Indexer1 != this.RealWord.Length-1) //ако има един символ който е различен от първата и последната буква
            {
                if (this.NewWord[Indexer1] == '_') //проверява дали вече сме вмъкнали дадената буква и
                {                                  //ако я има ни дава грешка,ако не - поставя я където трябва.
                    this.NewWord[Indexer1] = char.Parse(this.Letter);
                    NoValueCounter--;
                }
                else this.OnWrongAnswer();
            }
            else if(Indexer1 == Indexer2 && Indexer1 != 0 && Indexer1 == this.RealWord.Length - 1)
            {
                this.OnWrongAnswer(); //ако буквата се среща на последно място(където е видима) и никъде другаде, ни дава грешка.
            }
            //--------Проверки за букви с 2 позициии---------
            else if((this.Indexer1 != this.RealWord.Length-1 ) //ако буквата се среща не само на последно но и на друго(празно) място, я поставя.
                 && (this.Indexer2 == this.RealWord.Length-1))
            {
                if (this.NewWord[Indexer1] == '_')
                {
                    this.NewWord[Indexer1] = char.Parse(this.Letter);
                    NoValueCounter--;
                }
                else this.OnWrongAnswer();
            }
            else if ((this.Indexer1 == 0) //ако буквата се среща не само на първо но и на друго(празно) място, я поставя.
                 && (this.Indexer2 != 0))
            {
                if (this.NewWord[Indexer2] == '_')
                {
                    this.NewWord[Indexer2] = char.Parse(this.Letter);
                    NoValueCounter--;
                }
                else this.OnWrongAnswer();

            }
            else if(this.Indexer2 != this.RealWord.Length-1) //ако са две букви и не се срещат нито на първо нито на последно място, поставя и двете.
            {
                if (this.NewWord[Indexer1] == '_' && this.NewWord[Indexer2] == '_')
                {
                    this.NewWord[Indexer1] = char.Parse(this.Letter);
                    this.NewWord[Indexer2] = char.Parse(this.Letter);
                    NoValueCounter = NoValueCounter - 2;
                }
                else this.OnWrongAnswer();

            }
        }

        public void Render()
        {

            Console.SetCursorPosition(Console.WindowWidth / 2, 2);

            foreach (var item in NewWord)
            {
                Console.Write(item);
            }

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

                if (IsThereWord == false)
                {
                    this.MakeWordDifficult();
                    Render();
                    this.IsThereWord = true;
                }
                Thread.Sleep(50);

                if (Level.IsFilled == false)
                {
                    this.WordPut();
                    if (this.Word.Contains(this.Letter))
                    {
                        NoFirstAndLastLetter();
                        TwoLettersControl();
                        this.Render();

                        if (NoValueCounter < 0)
                        {
                            this.Level.IsFilled = true;
                            Console.Clear();
                        }


                    }
                    else if (this.Letter != "1" || this.Letter != "2")
                    {
                        this.OnWrongAnswer();
                    }
                }
                else
                {
                    this.RandomNumber = Random.Next(0, Level.TheWordsArray.Length - 1);
                    this.Word = this.Level.TheWordsArray[this.RandomNumber];
                    this.RealWord = this.Word.ToCharArray();
                    this.Level.IsFilled = false;
                    this.WrongCounter = 5;
                    this.IsThereWord = false;
                    this.SpaceCounter = 0;
                }

            }
        }
    }
}
