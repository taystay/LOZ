using LOZ.DungeonClasses;
using System.Collections.Generic;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class OpenTopDoor : ICommand
    {
        public OpenTopDoor() { }
        public void execute()
        {
            RoomReference.GetCurrRoom().UpdateExterior(DoorType.Hole, DoorLocation.Top);
            IRoom nextRoom = RoomReference.GetChangeRoom(0, -1, 0);
            if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Hole, DoorLocation.Bottom);

        }
    }
}
