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
        private Dictionary<Rectangle, Room> listOfRooms;
        private string folder;
        
        public IO(Dictionary<Rectangle, Room> rooms , string folderPathName) {
            listOfRooms = rooms;
            folder = folderPathName;
          
        }

        public void Parse()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-6.0
            string[] allMapsPaths = Directory.GetFiles(folder);

            foreach (string pathName in allMapsPaths) {
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

                ParseToBlock.ParseRoom(objects, reader);
                string enemyRow = reader.ReadLine();
                if (enemyRow!= null)
                    ParseToEnemy.ParseEnemy(objects, enemyRow);

                string itemRow = reader.ReadLine();
                if (itemRow != null)
                    ParseToItem.ParseItem(objects, itemRow);


                listOfRooms.Add(new Rectangle(xPosition,yPosition, zPosition, 0), new DungeonRoom(objects));
                
                reader.Close();

            }
            listOfRooms.Add(new Rectangle(3, 7 , 0, 0), new DevRoom());

        }

    }
}
