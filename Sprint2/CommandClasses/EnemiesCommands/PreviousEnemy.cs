using Sprint2.GameState;

namespace Sprint2.CommandClasses 
{ 
    class PreviousEnemy :ICommand
    {
        public PreviousEnemy()
        {
        }
        public void execute()
        {
            GameObjects.Enemies.IterateReverse();
        }
    }
}
