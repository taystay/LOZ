using LOZ.GameStateReference;


namespace LOZ.CommandClasses
{
    class SwitchRoomRightClick : ICommand
    {
        public SwitchRoomRightClick() { }
        public void execute() =>
            RoomReference.NextRoom(-1);
    }
}
