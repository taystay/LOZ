using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class LeftMove :ICommand
    {
        public LeftMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionLeft();
            GameObjects.Instance.Link.Move();
        }
    }
}
