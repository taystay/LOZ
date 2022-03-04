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
            CurrentRoom.Instance.Room.Link.ChangeDirectionUp();
            CurrentRoom.Instance.Room.Link.Move();
        }
    }
}
