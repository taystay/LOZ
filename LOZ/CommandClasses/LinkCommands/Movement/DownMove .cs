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
            CurrentRoom.Instance.Room.Link.ChangeDirectionDown();
            CurrentRoom.Instance.Room.Link.Move();
        }
    }
}
