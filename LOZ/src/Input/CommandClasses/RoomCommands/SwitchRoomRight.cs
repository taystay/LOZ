using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class SwitchRoomRight : ICommand
    {
        public SwitchRoomRight()
        {
        }
        public void execute()
        {
            RoomReference.SetRoomLocation(1, 0, 0);
        }
    }
}
