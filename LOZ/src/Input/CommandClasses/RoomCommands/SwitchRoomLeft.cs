﻿using LOZ.GameState;
using Microsoft.Xna.Framework.Input;
using LOZ.Room;

namespace LOZ.CommandClasses
{
    class SwitchRoomLeft : ICommand
    {
        public SwitchRoomLeft()
        {
        }
        public void execute()
        {
            //CurrentRoom.Instance.MoveRoomDirection(-1,0, 0);
            //CurrentRoom.Instance.Transition(-1,0,0);
            CurrentRoom.currentLocation.X -= 1;
            CurrentRoom.changeRoom = true;
        }
    }
}
