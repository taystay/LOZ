using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class UpMove :ICommand
    {
        public UpMove()
        {
        }
        public void execute()
        {
            CurrentRoom.Room.Link.ChangeDirectionUp();
            CurrentRoom.Room.Link.Move();
        }
    }
}
