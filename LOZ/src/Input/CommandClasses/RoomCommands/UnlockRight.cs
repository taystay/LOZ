using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockRight : ICommand
    {
        public UnlockRight()
        {
        }
        public void execute()
        {
            if(RoomReference.GetInventory().rupeeCount > 0)
            {
                RoomReference.GetCurrRoom().GetExtObj().ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
                RoomReference.GetInventory().UseKey();
                Dictionary<Point3D, IRoom> roomList = RoomReference.GetAllRooms();
                Point3D linkPos = RoomReference.GetCurrLocation();
                linkPos.X++;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomToRight = roomList[linkPos].GetExtObj();
                if (roomToRight != null)
                    roomToRight.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Door);
            }
            
        }
    }
}
