using System.Collections.Generic;
using System.IO;
using LOZ.Sound;
using System.Reflection;
using LOZ.Room;
using LOZ.GameStateReference;
using LOZ.LinkClasses;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.CommandClasses
{
    class EnterBossFight : ICommand
    {
        public EnterBossFight() { }
        public void execute()
        {
            RoomReference.SetAbsoluteRoom(4, 6, 1);
        }
    }
}
