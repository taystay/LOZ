using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.Collision;
using System.Collections.Generic;

namespace LOZ.CommandClasses
{
    class OpenRightDoor : ICommand
    {
        public OpenRightDoor()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            ExteriorObject exterior = room.exterior;
            if(exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Hole);
            }
            Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
            Point3D linkPos = CurrentRoom.Instance.linkCoor;
            linkPos.X++;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomToRight = roomList[linkPos].exterior;
            if (roomToRight != null)
                roomToRight.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Hole);

        }
    }
}
