using System.IO;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    internal class ParseToBlock
    {
        internal static void ParseRoom(List<IGameObjects> obj, StreamReader reader)
        {
            int xIndex = 0, yIndex = 0;
            Point location = DungeonClasses.DungeonInfo.Inside.Location;
            location.X += 24;
            location.Y += 24;
            int leftSide = location.X;

            while (reader.Peek() != 1 && yIndex != 7){
                string lineRead = reader.ReadLine();
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-6.0
                string[] words = lineRead.Split(',');

                while (xIndex < 12) {
                    obj.Add(Convert(words[xIndex], location.X, location.Y));
                    location.X += 48;
                    xIndex++;

                    if (xIndex == 12)
                    {
                        location.Y += 48;
                        location.X = leftSide;
                    }
                }
                xIndex = 0;
                yIndex++;
            }

        }
        private static IGameObjects Convert(string s, int x, int y)
        {
            Point location = new Point(x, y);
            IGameObjects returnVal;
            switch(s)
            {
                case "blackB":
                    returnVal = new BlackTileBlock(location);
                    break;
                case "blueS":
                    returnVal = new BlueSandBlock(location);
                    break;
                case "blueT":
                    returnVal = new BlueTriangleBlock(location);
                    break;
                case "darkB":
                    returnVal = new DarkBlueBlock(location);
                    break;
                case "S1":
                    returnVal = new MulticoloredBlock1(location);
                    break;
                case "S2":
                    returnVal = new MulticoloredBlock2(location);
                    break;
                case "blueB":
                    returnVal = new SolidBlueBlock(location);
                    break;
                case "stairB":
                    returnVal = new StairsBlock(location);
                    break;
                default:
                    returnVal = new BlackTileBlock(new Point(0, 0));
                    break;
            }

            return returnVal;
        }
    }
}
