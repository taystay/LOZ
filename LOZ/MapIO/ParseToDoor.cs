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
            DoorType[] doors = new DoorType[4];

            while (index < 4)
            {

                //https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-6.0#methods for string methods
                commaPosition = lineRead.IndexOf(',', i);

                switch (lineRead.Substring(i,commaPosition))
                {
                    case "door":
                        doors[index] = DoorType.Door;
                        break;
                    case "wall":
                        doors[index] = DoorType.Wall;
                        break;
                    case "brokenWall":
                        doors[index] = DoorType.Hole;
                        break;
                    case "locked":
                        doors[index] = DoorType.KeyDoor;
                        break;
                    case "shut":
                        doors[index] = DoorType.CrackedDoor;
                        break;
                    default:
                        doors[index] = DoorType.Door;
                        break;
                }

                i += commaPosition;
                index++;


            }

            obj.Add(new ExteriorObject(doors[0], doors[1], doors[2], doors[3]));

        }
    
    }
}
