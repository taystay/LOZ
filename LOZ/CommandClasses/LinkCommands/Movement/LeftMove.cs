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
            CurrentRoom.Instance.Room.Link.ChangeDirectionLeft();
            CurrentRoom.Instance.Room.Link.Move();
        }
    }
}
