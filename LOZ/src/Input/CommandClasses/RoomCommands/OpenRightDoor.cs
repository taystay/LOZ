using LOZ.DungeonClasses;
using LOZ.GameStateReference;
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
            RoomReference.GetCurrRoom().UpdateExterior(DoorType.Hole, DoorLocation.Right);
            IRoom nextRoom = RoomReference.GetChangeRoom(1, 0, 0);
            if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Hole, DoorLocation.Left);
        }
    }
}
