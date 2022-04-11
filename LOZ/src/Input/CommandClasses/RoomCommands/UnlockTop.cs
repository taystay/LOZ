﻿using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockTop : ICommand
    {
        public UnlockTop()
        {
        }
        public void execute()
        {
            if(RoomReference.GetInventory().keyCount > 0)
            {
                RoomReference.GetCurrRoom().UpdateExterior(DoorType.Door, DoorLocation.Top);
                RoomReference.GetInventory().UseKey();
                IRoom nextRoom = RoomReference.GetChangeRoom(0, -1, 0);
                if (nextRoom != null) nextRoom.UpdateExterior(DoorType.Door, DoorLocation.Bottom);
            }
        }
    }
}
