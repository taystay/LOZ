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
            CurrentRoom.Instance.Room.Link.ChangeDirectionRight();
            CurrentRoom.Instance.Room.Link.Move();
        }
    }
}
