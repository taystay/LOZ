using LOZ.GameState;

namespace LOZ.CommandClasses
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
