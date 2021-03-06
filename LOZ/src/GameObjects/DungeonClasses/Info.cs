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

        //Hitbox rectangles outside of room...
        public static Rectangle singleTopBox = new Rectangle(196, 436 - BlockWidth, 576, BlockWidth);
        public static Rectangle topHalfBox = new Rectangle(196, 436 - BlockWidth, 576 / 2 - 24, BlockWidth);
        public static Rectangle topHalfBox2 = new Rectangle(196 + DoorToCornerWidth - BlockWidth / 2, 436 - BlockWidth, 576 / 2 - 24, BlockWidth);
        public static Rectangle topDoorCollider = new Rectangle(topHalfBox2.X - DoorWidth, topHalfBox2.Y - BlockWidth, BlockWidth * 3, BlockWidth);

        public static Rectangle singleLeftBox = new Rectangle(196 - BlockWidth, 436, BlockWidth, Inside.Height);
        public static Rectangle leftHalfBox = new Rectangle(196 - BlockWidth, 436, BlockWidth, 338 / 2 - 24);
        public static Rectangle leftHalfBox2 = new Rectangle(196 - BlockWidth, 436 + DoorToCornerHeight - 24, BlockWidth, 338 / 2 - 24);
        public static Rectangle leftDoorCollider = new Rectangle(196 - BlockWidth - BlockWidth, 436 + DoorToCornerHeight - 24 - DoorWidth, BlockWidth, BlockWidth * 3);

        public static Rectangle singleRightBox = new Rectangle(196 + Inside.Width, 436, BlockWidth, 338);
        public static Rectangle rightHalfBox = new Rectangle(196 + Inside.Width, 436, BlockWidth, 338 / 2 - 24);
        public static Rectangle rightHalfBox2 = new Rectangle(196 + Inside.Width, 436 + DoorToCornerHeight - 24, BlockWidth, 338 / 2 - 24);
        public static Rectangle rightDoorCollider = new Rectangle(196 + Inside.Width + BlockWidth, 436 + DoorToCornerHeight - 24 - DoorWidth, BlockWidth, BlockWidth * 3);

        public static Rectangle singleBottomBox = new Rectangle(196, 436 + Inside.Height, 576, BlockWidth);
        public static Rectangle bottomHalfBox = new Rectangle(196, 436 + Inside.Height, 576 / 2 - 24, BlockWidth);
        public static Rectangle bottomHalfBox2 = new Rectangle(196 - 24 + DoorToCornerWidth, 436 + Inside.Height, 576 / 2 - 24, BlockWidth);
        public static Rectangle bottomDoorCollider = new Rectangle(topHalfBox2.X - DoorWidth, topHalfBox2.Y + Inside.Height + BlockWidth * 2, BlockWidth * 3, BlockWidth);

        public static Rectangle topDoorLocation = new Rectangle(450, 425, 50, 10);
        public static Rectangle rightDoorLocation = new Rectangle(750, 575, 10, 50);
        public static Rectangle leftDoorLocation = new Rectangle(200, 575, 10, 50);
        public static Rectangle bottomDoorLocation = new Rectangle(450, 750, 50, 10);

        //Place link in room spots
        public static Point posX = new Point(Map.Location.X + DoorWidth, Map.Location.Y + DoorToCornerHeight + BlockWidth);
        public static Point negX = new Point(Map.Location.X + Map.Width - DoorWidth, Map.Location.Y + DoorToCornerHeight + BlockWidth);
        public static Point posY = new Point(Map.Location.X + DoorToCornerWidth + BlockWidth, Map.Location.Y + DoorWidth);
        public static Point negY = new Point(Map.Location.X + DoorToCornerWidth + BlockWidth, Map.Location.Y + Map.Height - DoorWidth);
        public static Point Enter211 = new Point(Map.Location.X + 3 * BlockWidth + 24, Map.Location.Y + 2 * BlockWidth);
        public static Point Leave211 = new Point(Map.Location.X + 7 * BlockWidth + 24, Map.Location.Y + 6 * BlockWidth - 24);


    }
}
