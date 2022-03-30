using System;
using System.Collections.Generic;
using System.Text;
using LOZ.GameState;
using LOZ.CommandClasses;
using LOZ.DungeonClasses;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockTop : ICommand
    {
        public UnlockTop()
        {
        }
        public void execute()
        {
            if(Room.RoomInventory.getItemCounts().keys >= 1)
            {
                CurrentRoom.Instance.Room.exterior.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Door);
                Room.RoomInventory.UseKey();
                Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
                Point3D linkPos = CurrentRoom.Instance.linkCoor;
                linkPos.Y--;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomAbove = roomList[linkPos].exterior;
                if (roomAbove != null)
                    roomAbove.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Door);
            }

            
        }
    }
}
