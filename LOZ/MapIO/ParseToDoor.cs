using LOZ.Collision;
using LOZ.EnvironmentalClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.SpriteClasses.BlockSprites;

namespace LOZ.MapIO
{
   internal class ParseToDoor
    {
        internal static void ParseDoor(List<IGameObjects> obj, string lineRead)
        {

            int index = 0;
            int i = 0;
            int commaPosition = 0;

            while (index < 4)
            {
                commaPosition = lineRead.IndexOf(',', i);
                Point doorLocation;
                DoorLocation side;
                if (index == 0) {
                    doorLocation = new Point(DungeonInfo.DoorToCornerWidth, 0);
                    side = DoorLocation.Top;
                }
                else if (index == 1)
                {
                    doorLocation = new Point(DungeonInfo.DungeonWidth, DungeonInfo.DoorToCornerHeight);
                    side = DoorLocation.Right;
                }
                else if (index == 2)
                {
                    doorLocation = new Point(DungeonInfo.DoorToCornerWidth, DungeonInfo.DungeonHeight);
                    side = DoorLocation.Left;
                }
                else
                {
                    doorLocation = new Point(0, DungeonInfo.DoorToCornerHeight);
                    side = DoorLocation.Bottom; 

                }

                obj.Add(Convert(lineRead, side, doorLocation));
           
            }

        }
        private static IGameObjects Convert(string s, DoorLocation side, Point location)
        {
            IGameObjects returnVal;
            switch (s)
            {
                case "door":
                    returnVal = new DoorObject(location, side);
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
