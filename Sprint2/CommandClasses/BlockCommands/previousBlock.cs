using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class previousBlock : ICommand
    {
        public previousBlock()
        {
        }
        public void execute()
        {
            GameObjects.Blocks.IterateForward();
        }
    }
}
