using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockLeft : ICommand
    {
        public UnlockLeft()
        {
        }
        public void execute()
        {
            if(RoomReference.GetInventory().keyCount > 0)
            {
                RoomReference.GetCurrRoom().GetExtObj().ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Door);
                RoomReference.GetInventory().UseKey();
                Dictionary<Point3D, IRoom> roomList = RoomReference.GetAllRooms();
                Point3D linkPos = RoomReference.GetCurrLocation();
                linkPos.X--;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomToLeft = roomList[linkPos].GetExtObj();
                if (roomToLeft != null)
                    roomToLeft.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
            } 
            
        }
    }
}
