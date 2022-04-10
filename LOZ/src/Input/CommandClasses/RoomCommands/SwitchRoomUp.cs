using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class SwitchRoomUp : ICommand
    {
        public SwitchRoomUp()
        {
        }
        public void execute()
        {
            RoomReference.SetRoomLocation(0, -1, 0);
        }
    }
}
