using System.IO;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using LOZ.GameState;
using LOZ.CommandClasses.RoomCommands;
using LOZ.LinkClasses;

namespace LOZ.MapIO
{
    internal class ParseToBlock
    {
        internal static void ParseRoom(List<IGameObjects> obj, StreamReader reader)
        {
            bool basementFlag = false;
            int xIndex = 0, yIndex = 0;
            Point location = DungeonClasses.Info.Inside.Location;
            location.X += 24;
            location.Y += 24;
            int leftSide = location.X;
            int dynamicHeight = 7;
           

            while (reader.Peek() != 1 && yIndex != dynamicHeight){
                //https://docs.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/general/file-io-operation
                string lineRead = reader.ReadLine();
                if (lineRead == null)
                    break;
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-6.0
                string[] words = lineRead.Split(',');

                if (words[0].Equals("brick") && !basementFlag)
                {
                    location.X -= 96;
                    location.Y -= 96;
                    leftSide = location.X;
                    dynamicHeight = 11;
                    basementFlag = true;
                    obj.Add(new DoorCollider(new Rectangle(location.X + 24 + 96, location.Y - 48, 48, 48), new LeaveBasement(), typeof(ILink)));
                    obj.Add(new InvisibleBlock(new Point(location.X - 24, location.Y - 72), 48 * 16, 48));
                    obj.Add(new InvisibleBlock(new Point(location.X - 72, location.Y - 24), 48, 48 * 11));
                    obj.Add(new InvisibleBlock(new Point(location.X - 24 + (48*16), location.Y - 24), 48, 48 * 11));
                    obj.Add(new InvisibleBlock(new Point(location.X - 24, location.Y - 24 + (48 * 11)), 48 * 16, 48));
                }

               

                for (int i=0; i< words.Length; i++) { 
                    obj.Add(Convert(words[xIndex], location.X, location.Y));
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
                case "ladder":
                    returnVal = new LadderBlock(location);
                    break;
                case "brick":
                    returnVal = new BasementBlock(location);
                    break;
                default:
                    returnVal = new BlackTileBlock(new Point(0, 0));
                    break;
            }

            return returnVal;
        }
    }
}
