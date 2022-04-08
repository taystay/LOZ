using System;
using System.Collections.Generic;
using System.Text;
using LOZ.GameState;
using LOZ.CommandClasses;
using LOZ.DungeonClasses;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockLeft : ICommand
    {
        public UnlockLeft()
        {
        }
        public void execute()
        {
            if(Room.RoomInventory.keyCount > 0)
            {
                CurrentRoom.Instance.Room.exterior.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Door);
                Room.RoomInventory.UseKey();
                Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
                Point3D linkPos = CurrentRoom.Instance.linkCoor;
                linkPos.X--;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomToLeft = roomList[linkPos].exterior;
                if (roomToLeft != null)
                    roomToLeft.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
            } 
            
        }
    }
}
