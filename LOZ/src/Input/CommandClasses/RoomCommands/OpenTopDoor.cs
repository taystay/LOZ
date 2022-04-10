using LOZ.DungeonClasses;
using System.Collections.Generic;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class OpenTopDoor : ICommand
    {
        public OpenTopDoor()
        {
        }
        public void execute()
        {
            IRoom room = RoomReference.GetCurrRoom();
            ExteriorObject exterior = room.GetExtObj();
            if (exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Hole);
            }
            Dictionary<Point3D, IRoom> roomList = RoomReference.GetAllRooms();
            Point3D linkPos = RoomReference.GetCurrLocation();
            linkPos.Y--;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomAbove = roomList[linkPos].GetExtObj();
            if (roomAbove != null)
                roomAbove.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Hole);

        }
    }
}
