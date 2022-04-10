using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.Room;
using LOZ.GameStateReference;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockBottom : ICommand
    {
        public UnlockBottom()
        {
        }
        public void execute()
        {
            if(RoomReference.GetInventory().keyCount > 0)
            {
                RoomReference.GetCurrRoom().GetExtObj().ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Door);
                RoomReference.GetInventory().UseKey();
                Dictionary<Point3D, IRoom> roomList = RoomReference.GetAllRooms();
                Point3D linkPos = RoomReference.GetCurrLocation();
                linkPos.Y++;
                if (roomList[linkPos] == null) return;
                ExteriorObject roomUnder = roomList[linkPos].GetExtObj();
                if (roomUnder != null)
                    roomUnder.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Door);
            }
            
        }
    }
}
