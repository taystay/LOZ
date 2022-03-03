using System.IO;
using System;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    class MapIO
    {
        Dictionary<Point, List<IGameObjects>> listOfRooms;
        string folder;
        public MapIO(Dictionary<Point, List<IGameObjects>> rooms , string folderPathName) {
            listOfRooms = rooms;
            folder = folderPathName;
        }

        public void Parse()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-6.0#system-io-directory-getfiles(system-string-system-string)
            string[] allMapsPaths = Directory.GetFiles(folder);

            foreach (string pathName in allMapsPaths) {
                StreamReader reader = new StreamReader(pathName);
                List<IGameObjects> objects = new List<IGameObjects>();

                string position = reader.ReadLine();
                int xPosition = Convert.ToInt32(position.Substring(1, 1));
                int yPosition = Convert.ToInt32(position.Substring(3, 1));

                ParseToDoor.ParseDoor(objects, reader.ReadLine());
                ParseToBlock.ParseRoom(objects, reader);
                ParseToEnemy.ParseEnemy(objects, reader);

                listOfRooms.Add(new Point(xPosition,yPosition), objects);
                reader.Close();

            }
        }

    }
}
