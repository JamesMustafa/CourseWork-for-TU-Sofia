using System;
namespace CourseWork
{
    public interface IUserInterface //не се използват
    {
        event EventHandler OnCheatPressed;
        event EventHandler OnExitPressed;

        void ProcessInput();
    }
}
