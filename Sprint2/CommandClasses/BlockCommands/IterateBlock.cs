using Sprint2.GameState;

namespace Sprint2.CommandClasses
{ 
    class IterateBlock : ICommand
    {
        public IterateBlock()
     { 
        }
        public void execute()
        {
            GameObjects.Blocks.IterateForward();
        }
    }
}
