using System.IO;
using System.Collections.Generic;
using System.Text;
using LOZ.Collision;

namespace LOZ.MapIO
{
    class MapIO
    {
        //private enum Tiles{ SolidBlue, Black, BlueSand, BlueTriangle, DarkBlue};
        //private enum BlockNum { _blockNum}
        Dictionary<string, List<IGameObjects>> listOfRooms;
        string folder;
        public MapIO(Dictionary<string, List<IGameObjects>> rooms, string folderPathName) {
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

                while (reader.Peek() != -1) {
                    string lineRead = reader.ReadLine();
                    ParseLine(objects, lineRead);
                }

            }
        }

        private void ParseLine(List<IGameObjects> obj, string lineRead) {

            int i=0;
            int commaPosition;
            //https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0#properties
            while (i< lineRead.Length)
            {
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-6.0#system-string-indexof(system-char)
 
            }

        }
    }
}
