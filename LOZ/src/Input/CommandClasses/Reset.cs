using LOZ.GameState;
using LOZ.MapIO;
using System.Collections.Generic;
using System.IO;
using LOZ.Sound;
using System.Reflection;

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
            CurrentRoom.Instance.linkCoor = new Point3D(3, 6, 0);
            PlaceLink.BottomDungeonDoor();
            Room.Link.Health = 6;
            Room.Link.MaxHealth = 6;
            Room.Link.ChangeDirectionUp();
            Room.RoomInventory.Reset();
            SoundManager.Instance.SoundToLoop(SoundEnum.Background);
        }
    }
}
