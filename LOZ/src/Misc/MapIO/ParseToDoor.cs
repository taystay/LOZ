using LOZ.Collision;
using LOZ.EnvironmentalClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.SpriteClasses.BlockSprites;
using LOZ.GameState;
using LOZ.CommandClasses.RoomCommands;

namespace LOZ.MapIO
{
   internal class ParseToDoor
    {
        internal static void ParseDoor(List<IGameObjects> obj, string lineRead)
        {
            int index = 0;
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-6.0
            string[] words = lineRead.Split(',');
            DoorType[] doors = new DoorType[4];

            while (index < 4)
            { 
                switch (words[index])
                {
                    case "breakable":
                        doors[index] = DoorType.Breakable;
                        break;
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
                index++;

            }
            new ExteriorObject(doors[0], doors[1], doors[2], doors[3], obj);
        
            //return new ExteriorObject(doors[0], doors[1], doors[2], doors[3], obj);
        }
    
    }
}
