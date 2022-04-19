using LOZ.DungeonClasses;
using System.Collections.Generic;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class OpenLeftDoor : ICommand
    {
        public OpenLeftDoor() { }
        public void execute()
        {
            RoomReference.GetCurrRoom().UpdateExterior(DoorType.Hole, DoorLocation.Left);
            IRoom nextRoom = RoomReference.GetChangeRoom(-1, 0, 0);
            if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Hole, DoorLocation.Right);
        }
    }
}
