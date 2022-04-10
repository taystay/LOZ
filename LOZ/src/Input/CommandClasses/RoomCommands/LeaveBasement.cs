using LOZ.GameStateReference;

namespace LOZ.CommandClasses.RoomCommands
{
    class LeaveBasement : ICommand
    {
        public LeaveBasement()
        {
        }
        public void execute()
        {
            //CurrentRoom.Instance.MoveRoomDirection(0, 0, -1);
            //CurrentRoom.Instance.Transition(0,0,-1);
            RoomReference.SetRoomLocation(0, 0, -1);

            //CurrentRoom.currentLocation.Z -= 1;
            RoomReference.SetChangeRoom();
        }
    }
}
