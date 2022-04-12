using System.IO;
using System.Collections.Generic;
using LOZ.Collision;


namespace LOZ.MapIO
{
    class IO
    {
        private static IO instance = new IO(); 

        public static IO Instance
        {
            get
            {
                return instance;
            }
        }
        public List<IGameObjects> ParseOW(string pathFile)
        {
            List<IGameObjects> roomObj = new List<IGameObjects>();
            StreamReader reader = new StreamReader(pathFile);
            reader.ReadLine();
            ParseWholeRoom.ParseOWDoc(roomObj, reader);
            reader.Close();
            return roomObj;
        }

        public List<IGameObjects> ParseRoom(string pathFile)
        {
            List<IGameObjects> roomObj = new List<IGameObjects>();
            //https://docs.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/general/file-io-operation
            StreamReader reader = new StreamReader(pathFile);
            string doorRow = reader.ReadLine();
            if (doorRow.Length > 0)
            {
                ParseToBlock.ParseRoom(roomObj, reader);
            }
            else
            {
                ParseWholeRoom.ParseWhole(roomObj, reader);
            }
            reader.Close();
            return roomObj;

        }

    }
}
