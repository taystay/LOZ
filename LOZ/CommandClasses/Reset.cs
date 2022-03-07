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
            ILink link = CurrentRoom.Instance.Room.Link;
            Dictionary<Rectangle, Room> maps = new Dictionary<Rectangle, Room>() ;
            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            IO allMap = new IO(maps, filePath + "/Content/DugeonRooms");
            allMap.Parse();
            CurrentRoom.Instance.Rooms = maps;
            CurrentRoom.Instance.Room.Link = link;
            CurrentRoom.Instance.Room.gameObjects.Add(link);

        }
    }
}
