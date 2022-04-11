using System.IO;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    internal class ParseWholeRoom
    {
        internal static void ParseWhole(List<IGameObjects> obj, StreamReader reader)
        {
            int xIndex = 0, yIndex = 0;
            Point location = DungeonClasses.Info.Map.Location;
            location.X += 24;
            location.Y += 24;
            int leftSide = location.X;
            string lineRead = reader.ReadLine();

            while (yIndex != 11)
            {
                string[] words = lineRead.Split(',');

                for (int i = 0; i < words.Length; i++)
                {
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
