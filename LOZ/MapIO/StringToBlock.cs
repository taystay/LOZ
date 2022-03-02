using System.IO;
using System;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    public static class StringToBlock
    {
        public static IGameObjects Convert(string s, int x, int y)
        {
            Point location = new Point(x, y);
            IGameObjects returnVal;
            switch(s)
            {
                case "BlackTileBlock":
                    returnVal = new BlackTileBlock(location);
                    break;
                case "BlueSandBlock":
                    returnVal = new BlueSandBlock(location);
                    break;
                case "BlueTriangleBlock":
                    returnVal = new BlueTriangleBlock(location);
                    break;
                case "DarkBlueBlock":
                    returnVal = new DarkBlueBlock(location);
                    break;
                case "MulticoloredBlock1":
                    returnVal = new MulticoloredBlock1(location);
                    break;
                case "MulticoloredBlock2":
                    returnVal = new MulticoloredBlock2(location);
                    break;
                case "SolidBlueBlock":
                    returnVal = new SolidBlueBlock(location);
                    break;
                case "StairsBlock":
                    returnVal = new StairsBlock(location);
                    break;
                default:
                    returnVal = null;
                    break;
            }

            return returnVal;
        }
    }
}
