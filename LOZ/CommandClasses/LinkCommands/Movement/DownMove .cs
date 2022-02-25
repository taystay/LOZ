using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class DownMove :ICommand
    {
        public DownMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionDown();
            GameObjects.Instance.Link.Move();
        }
    }
}
