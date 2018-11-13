using System;
using System.IO;

namespace CourseWork
{
    public abstract class Level
    {
        protected StreamReader stream;
        protected StreamWriter streamWriter;
        public int CheatNumber { get; set; }
        protected string FilePath { get; set; }
        public string TheWords { get; set; }
        public string NewWords { get; set; }
        public string[] TheWordsArray { get; set; }
        public bool IsFilled { get; set; }

        protected Level(int cheatNumber,string filePath, bool isFilled)
        {
            this.CheatNumber = cheatNumber;
            this.FilePath = filePath; //всяко ниво си има различно име на текстовия файл.
            this.stream = new StreamReader(filePath); //имаме достъп за четене от файла. //можем да редактираме файла.
            this.TheWords = stream.ReadToEnd(); //в този стринг се пази цялото съдържание на файла.
            this.TheWordsArray = new string[] { };
            this.TheWordsArray = TheWords.Split('\n'); //в този масив всяка дума има различен индекс.
            this.IsFilled = isFilled;
        }

        public void ExceptionButton()
        {
            throw new Exception("bye");
        }
    }
}
