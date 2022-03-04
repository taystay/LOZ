﻿using LOZ.GameState;
using LOZ.Collision;
using Microsoft.Xna.Framework.Input;

namespace LOZ.CommandClasses
{
    class SwitchRoomDown : ICommand
    {
        public SwitchRoomDown()
        {
        }
        public void execute()
        {
            Room room = CurrentRoom.Instance.Room;
            MouseState state = Mouse.GetState();

            CurrentRoom.Instance.MoveRoomDirection(0,1);
            CurrentRoom.Instance.LoadContent();
        }
    }
}