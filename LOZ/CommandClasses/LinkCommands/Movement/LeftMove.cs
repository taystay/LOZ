using Sprint2.GameState;
using LOZ.GameState;

namespace Sprint2.CommandClasses
{
    class LeftMove :ICommand
    {
        public LeftMove()
        {
        }
        public void execute()
        {
            TestingRoom.Instance.Link.ChangeDirectionLeft();
            TestingRoom.Instance.Link.Move();
        }
    }
}
