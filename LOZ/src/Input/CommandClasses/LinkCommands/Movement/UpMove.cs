using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class UpMove :ICommand
    {
        public UpMove()
        {
        }
        public void execute()
        {
            RoomReference.GetLink().ChangeDirectionUp();
            RoomReference.GetLink().Move();
        }
    }
}
