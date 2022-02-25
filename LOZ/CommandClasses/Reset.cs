using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class Reset : ICommand
    {
        public Reset() { 
        }

        public void execute() {
            GameObjects.Instance.Reset();
        }
    }
}
