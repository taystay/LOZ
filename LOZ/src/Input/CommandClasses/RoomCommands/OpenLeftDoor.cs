using LOZ.DungeonClasses;
using System.Collections.Generic;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class OpenLeftDoor : ICommand
    {
        public OpenLeftDoor()
        {
        }
        public void execute()
        {
            IRoom room = RoomReference.GetCurrRoom();
            ExteriorObject exterior = room.GetExtObj();
            if(exterior != null)
            {
                exterior.ChangeDoorOnUpdate(DoorLocation.Left, DoorType.Hole);
            }
            Dictionary<Point3D, IRoom> roomList = RoomReference.GetAllRooms();
            Point3D linkPos = RoomReference.GetCurrLocation();
            linkPos.X--;
            if (roomList[linkPos] == null) return;
            ExteriorObject roomToLeft = roomList[linkPos].GetExtObj();
            if (roomToLeft != null)
                roomToLeft.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Hole);

        }
    }
}
