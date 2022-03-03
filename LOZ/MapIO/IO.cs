using System.IO;
using System;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    class IO
    {
        Dictionary<Point, List<IGameObjects>> listOfRooms;
        string folder;
        public IO(Dictionary<Point, List<IGameObjects>> rooms , string folderPathName) {
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

                //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number parse a string to num
                int xPosition = Int32.Parse(position.Substring(1, 1));
                int yPosition = Int32.Parse(position.Substring(3, 1));

                ParseToDoor.ParseDoor(objects, reader.ReadLine());
                ParseToBlock.ParseRoom(objects, reader);
                ParseToEnemy.ParseEnemy(objects, reader);

                listOfRooms.Add(new Point(xPosition,yPosition), objects);
                reader.Close();

            }
            
        }

    }
}
