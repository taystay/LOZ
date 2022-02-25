using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class NextEnemy :ICommand
    {
        public NextEnemy()
        {
        }
        public void execute()
        {
            GameObjects.Enemies.IterateForward();
        }
    }
}
