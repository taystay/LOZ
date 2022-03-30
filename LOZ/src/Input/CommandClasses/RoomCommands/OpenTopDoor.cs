using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.Collision;
using System.Collections.Generic;

namespace LOZ.CommandClasses
{
    class OpenTopDoor : ICommand
    {
        public OpenTopDoor()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            ExteriorObject exterior = room.exterior;
            if(exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Top, DoorType.Hole);
            }
            Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
            Point3D linkPos = CurrentRoom.Instance.linkCoor;
            linkPos.Y--;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomAbove = roomList[linkPos].exterior;
            if (roomAbove != null)
                roomAbove.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Hole);

        }
    }
}
