using System;
using System.IO;

namespace CourseWork
{
    public abstract class Level
    {
        protected StreamReader stream;
        public int CheatNumber { get; set; }
        protected string FilePath { get; set; }
        public string TheWords { get; private set; }
        public string[] TheWordsArray { get; private set; }
        public bool IsFilled { get; set; }

        protected Level(int cheatNumber,string filePath, bool isFilled)
        {
            this.CheatNumber = cheatNumber;
            this.FilePath = filePath;
            this.stream = new StreamReader(filePath);
            this.TheWords = stream.ReadToEnd();
            this.TheWordsArray = new string[] { };
            this.TheWordsArray = TheWords.Split('\n');
            this.IsFilled = isFilled;
        }

        public virtual void Update()
        {

        }

        public void ExceptionButton()
        {

            throw new Exception("bye");
        }
        public void Cheat()
        {

        }
    }
}
