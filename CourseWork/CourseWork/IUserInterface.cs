using System;
namespace CourseWork
{
    public interface IUserInterface
    {
        event EventHandler OnCheatPressed;
        event EventHandler OnExitPressed;

        void ProcessInput();
    }
}
