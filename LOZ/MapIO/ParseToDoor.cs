using LOZ.Collision;
using LOZ.EnvironmentalClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LOZ.DungeonClasses;

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
                if (index == 0) {
                    doorLocation = new Point(DungeonInfo.DoorToCornerWidth, 0);
                }
                else if (index == 1)
                {
                    doorLocation = new Point(DungeonInfo.DungeonWidth, DungeonInfo.DoorToCornerHeight);
                }
                else if (index == 2)
                {
                    doorLocation = new Point(DungeonInfo.DoorToCornerWidth, DungeonInfo.DungeonHeight);
                }
                else
                {
                    doorLocation = new Point(0, DungeonInfo.DoorToCornerHeight);

                }

                obj.Add(Convert(lineRead, index, doorLocation));
           
            }

        }
        private static IGameObjects Convert(string s, int numberForDirect, Point location)
        {
            IGameObjects returnVal;
            switch (s)
            {
                case "door":
                    returnVal = new DoorObject(location, numberForDirect);
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
