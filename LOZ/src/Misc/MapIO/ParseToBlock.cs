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
            while (yIndex != 7) {
                string lineRead = reader.ReadLine();
                if (lineRead == null) break;            
                string[] words = lineRead.Split(',');
                for (int i=0; i < words.Length; i++) { 
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
            }

        }
    
    }
}
