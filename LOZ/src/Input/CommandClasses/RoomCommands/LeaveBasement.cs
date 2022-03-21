using System;
using System.Collections.Generic;
using System.Text;
using LOZ.GameState;

namespace LOZ.CommandClasses.RoomCommands
{
    class LeaveBasement : ICommand
    {
        public LeaveBasement()
        {
        }
        public void execute()
        {
            CurrentRoom.Instance.MoveRoomDirection(0, 0, -1);
        }
    }
}
