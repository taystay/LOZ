using System.IO;
using LOZ.Room;
using System.Collections.Generic;
using LOZ.Collision;
using LOZ.DungeonClasses;


namespace LOZ.MapIO
{
    class IO
    {
        private string[] allRoomPathName;
        private static IO instance = new IO();
        

        public static IO Instance
        {
            get
            {
                return instance;
            }
        }

        public List<IGameObjects> ParseRoom(string pathFile) { 

            List<IGameObjects> roomObj = new List<IGameObjects>();

            //https://docs.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/general/file-io-operation
            StreamReader reader = new StreamReader(pathFile);
            string roomName = reader.ReadLine();

            string doorRow = reader.ReadLine();
            if (doorRow.Length > 0)
            {
                ParseToDoor.ParseDoor(roomObj, doorRow);
                ParseToBlock.ParseRoom(roomObj, reader);
            }
            else {
                ParseWholeRoom.ParseWhole(roomObj, reader);
            }

            reader.Close();
            return roomObj;

        }



        //private Dictionary<Point3D, Room> listOfRooms;
        //private string folder;

        //public IO(Dictionary<Point3D, Room> rooms , string folderPathName) {
        //    listOfRooms = rooms;
        //    folder = folderPathName;

        //}

        //public List<IGameObjects> ParsePathToBlocks(string path)
        //{
        //    List<IGameObjects> objToReturn = new List<IGameObjects>();
        //    return objToReturn;
        //}

        //public void Parse()
        //{
        //    //https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-6.0
        //    string[] allMapsPaths = Directory.GetFiles(folder);

        //    foreach (string pathName in allMapsPaths) {
        //        //https://docs.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/general/file-io-operation
        //        StreamReader reader = new StreamReader(pathName);
        //        List<IGameObjects> objects = new List<IGameObjects>();

        //        string position = reader.ReadLine();
        //        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
        //        //parse a string to num
        //        int xPosition = Int32.Parse(position.Substring(2, 1));
        //        int yPosition = Int32.Parse(position.Substring(4, 1));
        //        int zPosition = Int32.Parse(position.Substring(6, 1));

        //        string doorRow = reader.ReadLine();
        //        ExteriorObject exteriorObj = null;
        //        if (doorRow.Length >0)
        //            exteriorObj = ParseToDoor.ParseDoor(objects, doorRow);

        //        int offset = objects.Count;

        //        ParseToBlock.ParseRoom(objects, reader);
        //        string enemyRow = reader.ReadLine();
        //        if (enemyRow!= null)
        //            ParseToEnemy.ParseEnemy(objects, enemyRow, offset);

        //        string itemRow = reader.ReadLine();
        //        if (itemRow != null)
        //            ParseToItem.ParseItem(objects, itemRow, offset);

        //        Room room = new DungeonRoom(objects);
        //        room.exterior = exteriorObj;
        //        listOfRooms.Add(new Point3D(xPosition,yPosition, zPosition), room);

        //        reader.Close();

        //    }
        //    listOfRooms.Add(new Point3D(0, 7 , 0), new DevRoom());

        //    List<IGameObjects> objs = listOfRooms[new Point3D(3, 2, 0)].GameObjects;
        //    foreach(IGameObjects item in objs)
        //    {
        //        if(TypeC.Check(item, typeof(AbstractEnemy)))
        //        {
        //            AbstractEnemy e = (AbstractEnemy)item;
        //            e.hasKey = true;
        //            break;
        //        }
        //    }
        //}

    }
}
