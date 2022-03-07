using Microsoft.Xna.Framework;

namespace LOZ.DungeonClasses
{
    public static class Info
    {
        //Variables for screen dimensions
        public const int screenWidth = 968;
        public const int screenHeight = 968;

        //Variables to get to where the doors are
        public const int DoorToCornerWidth = 336;
        public const int DoorToCornerHeight = 216;

        //Variables defining the doorways
        public const int DoorWidth = 96;
        public const int DoorHeight = 96;

        //Width of entire dungeon
        public const int DungeonWidth = 768;
        public const int DungeonHeight = 528;

        //Width of a block
        public const int BlockWidth = 48;

        //Rectangles pertaining to the dungeon's dimensions
        public static Rectangle Map = new Rectangle(100, 340, 768, 528);
        public static Rectangle Inside = new Rectangle(196, 436, 576, 338);
    }
}
