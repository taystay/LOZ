using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockTop : ICommand
    {
        public UnlockTop()
        {
        }
        public void execute()
        {
            if(RoomReference.GetInventory().keyCount > 0)
            {
                RoomReference.GetCurrRoom().GetExtObj().ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Door);
                RoomReference.GetInventory().UseKey();
                Dictionary<Point3D, IRoom> roomList = RoomReference.GetAllRooms();
                Point3D linkPos = RoomReference.GetCurrLocation();
                linkPos.Y--;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomAbove = roomList[linkPos].GetExtObj();
                if (roomAbove != null)
                    roomAbove.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Door);
            }

            
        }
    }
}
