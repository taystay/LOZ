using System.IO;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    internal  class ParseToBlock
    {
        internal static void ParseRoom(List<IGameObjects> obj, StreamReader reader)
        {
            int i = 0, xIndex = 0, yIndex = 0, commaPosition = 0;
            Point location = new Point(100, 100);

            while (reader.Peek() != 1 && yIndex != 9){
                string lineRead = reader.ReadLine();

                while (xIndex < 14) {
                    //https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-6.0#system-string-indexof(system-char)
                    commaPosition = lineRead.IndexOf(',', i);

                    obj.Add(Convert(lineRead.Substring(i, commaPosition), location.X, location.Y));
                    i += commaPosition;
                    location.X += 48;
                    xIndex++;

                    if (xIndex == 13)
                    {
                        location.Y += 48;
                        location.X = 100;
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
                case "s1":
                    returnVal = new MulticoloredBlock1(location);
                    break;
                case "s2":
                    returnVal = new MulticoloredBlock2(location);
                    break;
                case "blueB":
                    returnVal = new SolidBlueBlock(location);
                    break;
                case "stairB":
                    returnVal = new StairsBlock(location);
                    break;
                case "wall":
                    returnVal = new InvisibleBlock(location);
                    break;
                default:
                    returnVal = null;
                    break;
            }

            return returnVal;
        }
    }
}
