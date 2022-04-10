using LOZ.Room;

namespace LOZ.CommandClasses
{
    class SwitchRoomLeftClick : ICommand
    {
        public SwitchRoomLeftClick()
        {
        }
        public void execute()
        {
            CurrentRoom.Instance.NextRoom(1);
        }
    }
}
