using LOZ.Room;

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
            //sCurrentRoom.Instance.Transition(0,0,-1);
            CurrentRoom.currentLocation.Z -= 1;
            CurrentRoom.changeRoom = true;
        }
    }
}
