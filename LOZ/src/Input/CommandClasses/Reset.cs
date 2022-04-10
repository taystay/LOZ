using LOZ.MapIO;
using System.Collections.Generic;
using System.IO;
using LOZ.Sound;
using System.Reflection;
using LOZ.Room;

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
            //IO allMap = new IO(maps, filePath + "/Content/DugeonRooms/DugeonRooms");
            //allMap.Parse();
            RoomMaker rooms = new RoomMaker(filePath + "/Content/DugeonRooms/DugeonRooms");
            maps = rooms.CreateAllRooms();
            CurrentRoom.Instance.LoadContents(maps);
            //CurrentRoom.Instance._allRooms = maps;
            CurrentRoom.currentLocation = new Point3D(3, 6, 0);
            PlaceLink.BottomDungeonDoor();
            CurrentRoom.link.Health = 6;
            CurrentRoom.link.MaxHealth = 6;
            CurrentRoom.link.ChangeDirectionUp();
            //CurrentRoom.RoomInventory.Initialize();
            SoundManager.Instance.SoundToLoop(SoundEnum.Background);
        }
    }
}
