using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class Attack :ICommand
    {
        public Attack()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.Attack();
        }
    }
}
