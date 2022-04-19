using System.IO;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    internal class ConvertBlock
    {
        internal static IGameObjects BlockConvert(string s, int x, int y) => s switch {
            "invisB" => new InvisibleBlock(new Rectangle(x-24,y-24,48,48)),
            "blackB" => new BlackTileBlock(new Point(x,y)),
            "blueS" => new BlueSandBlock(new Point(x, y)),
            "blueT" => new BlueTriangleBlock(new Point(x, y)),
            "darkB" => new DarkBlueBlock(new Point(x, y)),
            "S1" => new MulticoloredBlock1(new Point(x, y)),
            "S2" => new MulticoloredBlock2(new Point(x, y)),
            "blueB" => new SolidBlueBlock(new Point(x, y)),
            "stairB" => new StairsBlock(new Point(x, y)),
            "ladder" => new LadderBlock(new Point(x, y)),
            "brick" => new BasementBlock(new Point(x, y)),
            "wat" => new WaterTile(new Point(x, y)),
            "san" => new SandTile(new Point(x, y)),
            "top" => new TopSandWall(new Point(x, y)),
            "bot" => new BottomSandWall(new Point(x, y)),
            "bri" => new BridgeTile(new Point(x, y)),
            _ => new BlackTileBlock(new Point(x, y)),
        };      
    }
}
