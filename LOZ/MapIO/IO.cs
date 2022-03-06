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
        private Dictionary<Point, DungeonRoom> listOfRooms;
        private string folder;
        public IO(Dictionary<Point, DungeonRoom> rooms , string folderPathName) {
            listOfRooms = rooms;
            folder = folderPathName;
          
        }

        public void Parse()
        {   
            string[] allMapsPaths = Directory.GetFiles(folder);

            foreach (string pathName in allMapsPaths) {
                StreamReader reader = new StreamReader(pathName);
                List<IGameObjects> objects = new List<IGameObjects>();

                string position = reader.ReadLine();
                //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                //parse a string to num
                int xPosition = Int32.Parse(position.Substring(2, 1));
                int yPosition = Int32.Parse(position.Substring(4, 1));

                ParseToDoor.ParseDoor(objects, reader.ReadLine());
                ParseToBlock.ParseRoom(objects, reader);
                string enemyRow = reader.ReadLine();
                if (enemyRow!= null)
                    ParseToEnemy.ParseEnemy(objects, enemyRow);

                string itemRow = reader.ReadLine();
                if (itemRow != null)
                    ParseToItem.ParseItem(objects, itemRow);


                listOfRooms.Add(new Point(xPosition,yPosition), new DungeonRoom(objects));
                reader.Close();

            }
            
        }

    }
}
