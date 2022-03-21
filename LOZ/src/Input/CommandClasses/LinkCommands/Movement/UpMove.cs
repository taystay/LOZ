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
            Room.Link.ChangeDirectionUp();
            Room.Link.Move();
        }
    }
}
