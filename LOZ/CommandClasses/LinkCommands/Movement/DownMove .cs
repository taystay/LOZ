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
            CurrentRoom.Room.Link.ChangeDirectionDown();
            CurrentRoom.Room.Link.Move();
        }
    }
}
