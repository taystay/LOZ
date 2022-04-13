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
        public List<IGameObjects> ParseOW(string pathFile, int startline, int endline)
        {
            List<IGameObjects> roomObj = new List<IGameObjects>();
            StreamReader reader = new StreamReader(pathFile);

            //start at desired location
            for (int i = 0; i < startline - 1; i++)
                reader.ReadLine();

            //close reader and parse number of lines specified
            ParseWholeRoom.ParseOWDoc(roomObj, reader, endline - startline + 1);
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
