using LOZ.GameState;
namespace LOZ.CommandClasses
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
