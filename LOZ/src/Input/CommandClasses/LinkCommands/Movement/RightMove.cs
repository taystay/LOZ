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
            Room.Link.ChangeDirectionRight();
            Room.Link.Move();
        }
    }
}
