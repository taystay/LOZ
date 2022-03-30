using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.Collision;
using System.Collections.Generic;

namespace LOZ.CommandClasses
{
    class OpenLeftDoor : ICommand
    {
        public OpenLeftDoor()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            ExteriorObject exterior = room.exterior;
            if(exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Hole);
            }
            Dictionary<Point3D, Room> roomList = CurrentRoom.Instance.Rooms;
            Point3D linkPos = CurrentRoom.Instance.linkCoor;
            linkPos.X--;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomToLeft = roomList[linkPos].exterior;
            if (roomToLeft != null)
                roomToLeft.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Hole);

        }
    }
}
