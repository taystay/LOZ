using LOZ.GameState;
using LOZ.MapIO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;
using System.Reflection;
using LOZ.LinkClasses;

namespace LOZ.CommandClasses
{
    class Reset : ICommand
    {
        public Reset()
        {
        }
        public void execute()
        {
            Dictionary<Point3D, Room> maps = new Dictionary<Point3D, Room>() ;
            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            IO allMap = new IO(maps, filePath + "/Content/DugeonRooms");
            allMap.Parse();
            CurrentRoom.Instance.Rooms = maps;
            Room.Link.Health = 6;
        }
    }
}
