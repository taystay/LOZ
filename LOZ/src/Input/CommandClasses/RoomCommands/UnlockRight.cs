using System;
using System.Collections.Generic;
using System.Text;
using LOZ.GameState;
using LOZ.CommandClasses;
using LOZ.DungeonClasses;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockRight : ICommand
    {
        public UnlockRight()
        {
        }
        public void execute()
        {
            if(Room.RoomInventory.rupeeCount > 0)
            {
                CurrentRoom.Instance.Room.exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
                Room.RoomInventory.UseKey();
                Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
                Point3D linkPos = CurrentRoom.Instance.linkCoor;
                linkPos.X++;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomToRight = roomList[linkPos].exterior;
                if (roomToRight != null)
                    roomToRight.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Door);
            }
            
        }
    }
}
