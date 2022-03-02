﻿using System.IO;
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
