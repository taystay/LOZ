﻿using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.Collision;

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
                
        }
    }
}
