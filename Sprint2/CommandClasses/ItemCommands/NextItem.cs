
using Sprint2.GameState;

namespace Sprint2.CommandClasses
{ 
    class NextItem :ICommand
    {
        public NextItem()
        {
        }
        public void execute()
        {
            GameObjects.Items.IterateReverse();
        }
    }
}
