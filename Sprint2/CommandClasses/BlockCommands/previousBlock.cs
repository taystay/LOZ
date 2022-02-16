using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class PreviousBlock : ICommand
    {
        public PreviousBlock()
        {
        }
        public void execute()
        {
            GameObjects.Blocks.IterateReverse();
        }
    }
}
