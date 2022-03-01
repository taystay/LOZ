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
            CurrentRoom.Room.Link.ChangeDirectionRight();
            CurrentRoom.Room.Link.Move();
        }
    }
}
