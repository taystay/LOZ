using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class TakeDamage :ICommand
    {
        public TakeDamage()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.TakeDamage();
        }
    }
}
