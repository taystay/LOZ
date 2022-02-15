using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class PreviousItem :ICommand
    {
        public PreviousItem()
        {
        }
        public void execute()
        {
            GameObjects.Items.IterateForward();
        }
    }
}
