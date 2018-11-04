using System;
namespace CourseWork
{
    public class LevelHard : Level
    {
        private const string path = "hard.txt";
        private const int cheats = 0;

        public LevelHard() : base(cheats,path,false)
        {
        }
    }
}
