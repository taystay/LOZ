using System.IO;
using System;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.GameState;

namespace LOZ.MapIO
{
    class IO
    {
        private Dictionary<Point3D, Room> listOfRooms;
        private string folder;
        
        public IO(Dictionary<Point3D, Room> rooms , string folderPathName) {
            listOfRooms = rooms;
            folder = folderPathName;
          
        }

        public void Parse()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-6.0
            string[] allMapsPaths = Directory.GetFiles(folder);

            foreach (string pathName in allMapsPaths) {
                //https://docs.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/general/file-io-operation
                StreamReader reader = new StreamReader(pathName);
                List<IGameObjects> objects = new List<IGameObjects>();

                string position = reader.ReadLine();
                //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                //parse a string to num
                int xPosition = Int32.Parse(position.Substring(2, 1));
                int yPosition = Int32.Parse(position.Substring(4, 1));
                int zPosition = Int32.Parse(position.Substring(6, 1));

                string doorRow = reader.ReadLine();
                if(doorRow.Length >0)
                    ParseToDoor.ParseDoor(objects, doorRow);

                int offset = objects.Count;

                ParseToBlock.ParseRoom(objects, reader);
                string enemyRow = reader.ReadLine();
                if (enemyRow!= null)
                    ParseToEnemy.ParseEnemy(objects, enemyRow, offset);

                string itemRow = reader.ReadLine();
                if (itemRow != null)
                    ParseToItem.ParseItem(objects, itemRow, offset);


                listOfRooms.Add(new Point3D(xPosition,yPosition, zPosition), new DungeonRoom(objects));
                
                reader.Close();

            }
            listOfRooms.Add(new Point3D(3, 7 , 0), new DevRoom());

        }

    }
}
