using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class SwitchRoomDown : ICommand
    {
        public SwitchRoomDown()
        {
        }
        public void execute()
        {
            RoomReference.SetRoomLocation(0, 1, 0);
        }
    }
}
