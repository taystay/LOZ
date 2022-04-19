using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class DownMove :ICommand
    {
        public DownMove() { }
        public void execute()
        {
            RoomReference.GetLink().ChangeDirectionDown();
            RoomReference.GetLink().Move();
        }
    }
}
