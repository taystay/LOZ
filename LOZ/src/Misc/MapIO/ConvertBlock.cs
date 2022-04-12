using System.IO;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    internal class ConvertBlock
    {
        internal static IGameObjects BlockConvert(string s, int x, int y)
        { 
            Point location = new Point(x, y);
            IGameObjects returnVal;
            switch (s)
            {
                case "invisB":
                    Rectangle r = new Rectangle(location.X - 24, location.Y - 24, 48, 48);
                    returnVal = new InvisibleBlock(r);
                    break;
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
                case "ladder":
                    returnVal = new LadderBlock(location);
                    break;
                case "brick":
                    returnVal = new BasementBlock(location);
                    break;
                case "wat":
                    returnVal = new WaterTile(location);
                    break;
                case "san":
                    returnVal = new SandTile(location);
                    break;
                case "top":
                    returnVal = new TopSandWall(location);
                    break;
                case "bot":
                    returnVal = new BottomSandWall(location);
                    break;
                case "bri":
                    returnVal = new BridgeTile(location);
                    break;
                default:
                    returnVal = new BlackTileBlock(new Point(0, 0));
                    break;
            }

            return returnVal;

        }
    }
}
