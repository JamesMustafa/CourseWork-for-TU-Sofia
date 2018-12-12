using System;
namespace CourseWork
{
    public class LevelNormal : Level
    {
        private const string path = "normal.txt";
        private const int cheats = 3;

        public LevelNormal():base(cheats,path,false)
        {
        }
    }
}
