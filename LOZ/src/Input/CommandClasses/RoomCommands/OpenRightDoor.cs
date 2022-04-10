using LOZ.DungeonClasses;
using LOZ.Room;
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
            IRoom room = RoomReference.GetCurrRoom();
            ExteriorObject exterior = room.GetExtObj();
            if(exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Hole);
            }
            Dictionary<Point3D, IRoom> roomList = CurrentRoom.Instance._allRooms;
            Point3D linkPos = RoomReference.GetCurrLocation();
            linkPos.X++;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomToRight = roomList[linkPos].GetExtObj();
            if (roomToRight != null)
                roomToRight.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Hole);

        }
    }
}
