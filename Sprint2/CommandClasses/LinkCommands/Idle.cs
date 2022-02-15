using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class Idle :ICommand
    {
        public Idle()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.Idle();
        }
    }
}
