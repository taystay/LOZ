using System;
using System.Collections.Generic;
using System.Text;
using LOZ.GameState;
using LOZ.CommandClasses;
using LOZ.DungeonClasses;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockBottom : ICommand
    {
        public UnlockBottom()
        {
        }
        public void execute()
        {
            if(Room.RoomInventory.keyCount > 0)
            {
                CurrentRoom.Instance.Room.exterior.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Door);
                Room.RoomInventory.UseKey();
                Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
                Point3D linkPos = CurrentRoom.Instance.linkCoor;
                linkPos.Y++;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomUnder = roomList[linkPos].exterior;
                if (roomUnder != null)
                    roomUnder.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Door);
            }
            
        }
    }
}
