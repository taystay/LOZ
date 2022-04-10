using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class LeftMove :ICommand
    {
        public LeftMove()
        {
        }
        public void execute()
        {
            RoomReference.GetLink().ChangeDirectionLeft();
            RoomReference.GetLink().Move();
        }
    }
}
