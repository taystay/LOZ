using LOZ.Room;

namespace LOZ.CommandClasses
{
    class RightMove :ICommand
    {
        public RightMove()
        {
        }
        public void execute()
        {
            RoomReference.GetLink().ChangeDirectionRight();
            RoomReference.GetLink().Move();
        }
    }
}
