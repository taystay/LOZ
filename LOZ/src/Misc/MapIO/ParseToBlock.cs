using System.IO;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    internal class ParseToBlock
    {
        internal static void ParseRoom(List<IGameObjects> obj, StreamReader reader)
        {
            int xIndex = 0, yIndex = 0;
            Point location = DungeonClasses.Info.Inside.Location;
            location.X += 24;
            location.Y += 24;
            int leftSide = location.X;
            string lineRead = reader.ReadLine();

            while (reader.Peek() > -1){
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-6.0
                string[] words = lineRead.Split(',');

                for (int i=0; i< words.Length; i++) { 
                    obj.Add(ConvertBlock.BlockConvert(words[xIndex], location.X, location.Y));
                    location.X += 48;
                    xIndex++;

                    if (xIndex == words.Length)
                    {
                        location.Y += 48;
                        location.X = leftSide;
                    }
                }
                xIndex = 0;
                yIndex++;

                //https://docs.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/general/file-io-operation
                lineRead = reader.ReadLine();
            }

        }
    
    }
}
