using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.Collision;
using System.Collections.Generic;

namespace LOZ.CommandClasses
{
    class OpenBottomDoor : ICommand
    {
        public OpenBottomDoor()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            ExteriorObject exterior = room.exterior;
            if (exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Hole);
            }
            Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
            Point3D linkPos = CurrentRoom.Instance.linkCoor;
            linkPos.Y++;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomUnder = roomList[linkPos].exterior;
            if (roomUnder != null)
                roomUnder.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Hole);
                
        }
    }
}
