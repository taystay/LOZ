using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class SwitchRoomLeft : ICommand
    {
        public SwitchRoomLeft()
        {
        }
        public void execute()
        {
            RoomReference.SetRoomLocation(-1, 0, 0);
        }
    }
}
