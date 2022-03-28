using System;
using System.Collections.Generic;
using System.Text;
using LOZ.GameState;
using LOZ.CommandClasses;
using LOZ.DungeonClasses;

namespace LOZ.CommandClasses.RoomCommands
{
    class UnlockBottom : ICommand
    {
        public UnlockBottom()
        {
        }
        public void execute()
        {
            if(Room.RoomInventory.getItemCounts().keys >= 1)
            {
                CurrentRoom.Instance.Room.exterior.ChangeDoorOnUpdate(DoorLocation.Bottom, DoorType.Door);
                Room.RoomInventory.UseKey();
            }
            
        }
    }
}
