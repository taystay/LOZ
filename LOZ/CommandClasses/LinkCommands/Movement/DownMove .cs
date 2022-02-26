using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class DownMove :ICommand
    {
        public DownMove()
        {
        }
        public void execute()
        {
            TestingRoom.Instance.Link.ChangeDirectionDown();
            TestingRoom.Instance.Link.Move();
        }
    }
}
