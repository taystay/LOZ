using LOZ.DungeonClasses;
using System.Collections.Generic;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class OpenBottomDoor : ICommand
    {
        public OpenBottomDoor()
        {
        }
        public void execute()
        {
            IRoom room = RoomReference.GetCurrRoom();
            ExteriorObject exterior = room.GetExtObj();
            if (exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Hole);
            }
            Dictionary<Point3D, IRoom> roomList = RoomReference.GetAllRooms();
            Point3D linkPos = RoomReference.GetCurrLocation();
            linkPos.Y++;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomUnder = roomList[linkPos].GetExtObj();
            if (roomUnder != null)
                roomUnder.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Hole);
                
        }
    }
}
