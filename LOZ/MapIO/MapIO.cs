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

            int i = 0;
            foreach (string pathName in allMapsPaths) {
                StreamReader reader = new StreamReader(pathName);
                List<IGameObjects> objects = new List<IGameObjects>();

                Point gridLocation = (Point)Convert.ChangeType(reader.ReadLine(), typeof(Point));

                while (reader.Peek() != -1) {
                    string lineRead = reader.ReadLine();
                    ParseLine(objects, lineRead);
                }

                listOfRooms.Add(gridLocation, objects);

               

            }
        }

        private void ParseLine(List<IGameObjects> obj, string lineRead) {

            int i=0;
            int commaPosition;
            Point location = new Point(100, 100);

            //https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0#properties
            while (i<lineRead.Length)
            {
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-6.0#system-string-indexof(system-char)
                commaPosition = lineRead.IndexOf(',',i);
             
                //https://docs.microsoft.com/en-us/dotnet/api/system.convert.changetype?view=net-6.0#system-convert-changetype(system-object-system-type)
                IGameObjects blockType = (IGameObjects) Convert.ChangeType(lineRead.Substring(i, commaPosition), typeof(IGameObjects));
                i += commaPosition;
                obj.Add(blockType);
              
            }

        }
    }
}
