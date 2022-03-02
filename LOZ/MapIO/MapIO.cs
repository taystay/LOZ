using System.IO;
using System;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
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

                ParseDoor(objects, reader.ReadLine());
                ParseRoom(objects, reader);

                listOfRooms.Add(new Point(xPosition,yPosition), objects);

            }
        }

        private void ParseRoom(List<IGameObjects> obj, StreamReader reader) {

            int i = 0, xIndex = 0, yIndex=0, commaPosition=0, ;
            
            Point location = new Point(100, 100);

            while (reader.Peek() != 1 && yIndex != 9) {
                string lineRead = reader.ReadLine();

                while (xIndex < 14)
                {
                    //https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-6.0#system-string-indexof(system-char)
                    commaPosition = lineRead.IndexOf(',', i);

                    obj.Add(StringToBlock.Convert(lineRead.Substring(i, commaPosition), location.X, location.Y));
                    i += commaPosition;
                    location.X += 48;
                    xIndex++;

                    if (xIndex == 13) {
                        location.Y += 48;
                        location.X = 100;                    
                    }
                }

                xIndex = 0;
                yIndex++;
            }

        }

        private void ParseDoor(List<IGameObjects> obj, string lineRead) {

            int index = 0;
            int i = 0;
            int commaPosition = 0;
            Point location = new Point(500, 100);

            while (index < 4) {
                commaPosition = lineRead.IndexOf(',', i);

                obj.Add(StringToDoor.Convert(lineRead.Substring(i, commaPosition), location.X, location.Y));
                if (index == 1)
                {

                }
                else if (index == 2)
                {

                }
                else { 
                
                }
            }
        
        }


    }
}
