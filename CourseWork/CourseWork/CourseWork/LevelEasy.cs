using System;
using System.IO;
namespace CourseWork
{
    public class LevelEasy : Level
    {
        private const string path = "easy.txt";
        private const int cheats = 5;

        public LevelEasy() : base(cheats, path,false)
        {
        }

    }
}

