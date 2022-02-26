using LOZ.GameState;
namespace Sprint2.CommandClasses
{
    class RightMove :ICommand
    {
        public RightMove()
        {
        }
        public void execute()
        {
            TestingRoom.Instance.Link.ChangeDirectionRight();
            TestingRoom.Instance.Link.Move();
        }
    }
}
