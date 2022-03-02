using LOZ.Collision;
using LOZ.EnvironmentalClasses;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
   public static class StringToDoor
    {
        public static IGameObjects Convert(string s, int x, int y)
        {
            Point location = new Point(x, y);
            IGameObjects returnVal;
            switch (s)
            {
                case "door":
                    returnVal = new BlackTileBlock(location);
                    break;
                case "wall":
                    returnVal = new BlueSandBlock(location);
                    break;
                case "brokenWall":
                    returnVal = new BlueTriangleBlock(location);
                    break;
                case "locked":
                    returnVal = new DarkBlueBlock(location);
                    break;
                case "shut":
                    returnVal = new MulticoloredBlock1(location);
                    break;
                default:
                    returnVal = null;
                    break;
            }

            return returnVal;
        }
    }
}
