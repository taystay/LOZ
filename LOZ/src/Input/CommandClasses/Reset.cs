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
    class Reset : ICommand
    {
        public Reset()
        {
        }
        public void execute()
        {
            Dictionary<Point3D, IRoom> maps = new Dictionary<Point3D, IRoom>();
            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            RoomMaker rooms = new RoomMaker(filePath + "/Content/DugeonRooms/DugeonRooms/");
            maps = rooms.CreateAllRooms();
            CurrentRoom.Instance.LoadContents(maps);
            CurrentRoom.currentLocation = new Point3D(3, 6, 1);
            CurrentRoom.link = new Link(new Point(Info.Map.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, Info.Map.Location.Y + Info.Map.Height - Info.DoorWidth - 24));
            SoundManager.Instance.SoundToLoop(SoundEnum.Background);
            GetReference.GetRef().CameraState.Reset();
        }
    }
}
