using System;
namespace CourseWork
{
    public class KeyboardInterface : IUserInterface //не се използват
    {

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key.Equals(ConsoleKey.F2))
                {
                    this.OnCheatPressed(this, new EventArgs());
                }
                if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    this.OnExitPressed(this, new EventArgs());
                }
            }
        }
        public event EventHandler OnCheatPressed;
        public event EventHandler OnExitPressed;
    }
}
