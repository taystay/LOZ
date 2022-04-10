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
            //CurrentRoom.Instance.MoveRoomDirection(1,0, 0);
            //CurrentRoom.Instance.Transition(1,0,0);
            //CurrentRoom.currentLocation.X += 1;
            //CurrentRoom.changeRoom = true;

            RoomReference.SetRoomLocation(1, 0, 0);
            RoomReference.SetChangeRoom();
        }
    }
}
