using LOZ.GameStateReference;

namespace LOZ.CommandClasses
{
    class SwitchRoomLeftClick : ICommand
    {
        public SwitchRoomLeftClick()
        {
        }
        public void execute()
        {
            RoomReference.NextRoom(1);
        }
    }
}
