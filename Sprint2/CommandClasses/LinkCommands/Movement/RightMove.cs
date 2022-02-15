using Sprint2.GameState;
namespace Sprint2.CommandClasses
{
    class RightMove :ICommand
    {
        public RightMove()
        {
        }
        public void execute()
        {
            GameObjects.Instance.Link.ChangeDirectionRight();
            GameObjects.Instance.Link.Move();
        }
    }
}
