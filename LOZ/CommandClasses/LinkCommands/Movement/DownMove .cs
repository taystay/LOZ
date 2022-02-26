using Sprint2.GameState;
using LOZ.GameState;

namespace Sprint2.CommandClasses
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
