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
            //CurrentRoom.Instance.MoveRoomDirection(0,1, 0);
            //CurrentRoom.Instance.Transition(0,1,0);
            //CurrentRoom.currentLocation.Y += 1;
            //CurrentRoom.changeRoom = true;

            RoomReference.SetRoomLocation(0, 1, 0);
            RoomReference.SetChangeRoom();
        }
    }
}
