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
            Room.Link.ChangeDirectionDown();
            Room.Link.Move();
        }
    }
}
