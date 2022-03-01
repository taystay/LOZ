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
            CurrentRoom.Room.Link.ChangeDirectionLeft();
            CurrentRoom.Room.Link.Move();
        }
    }
}
