﻿using LOZ.GameState;

namespace LOZ.CommandClasses
{
    class LeftMove :ICommand
    {
        public LeftMove()
        {
        }
        public void execute()
        {
            Room.Link.ChangeDirectionLeft();
            Room.Link.Move();
        }
    }
}