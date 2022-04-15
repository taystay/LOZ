using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses
{
    public static class SpriteStandardizeClass
    {
        //Block Sprite Rectangles
		public static Rectangle blueSandBlock = new Rectangle(41, 63, 32, 32);
        public static Rectangle basementTileSprite = new Rectangle(0, 0, 16, 16);
        public static Rectangle blackTileSprite = new Rectangle(7, 63, 32, 32);
        public static Rectangle blueTriangleSprite = new Rectangle(41, 29, 32, 32);
        public static Rectangle darkBlueSolidSprite = new Rectangle(75, 63, 32, 32);
        public static Rectangle ladderSprite = new Rectangle(17, 0, 16, 16);
        public static Rectangle multicolored1Sprite = new Rectangle(75, 29, 32, 32);
        public static Rectangle multicolored2Sprite = new Rectangle(109, 29, 32, 32);
        public static Rectangle solidBlueSprite = new Rectangle(7, 29, 32, 32);
        public static Rectangle stairsSprite = new Rectangle(109, 63, 32, 32);

        //Display Rectangles
        public static Rectangle PauseHudSprite = new Rectangle(0, 23, 256, 175 - 6);
        public static Rectangle HUDSprite = new Rectangle(0, 169, 256, 231 - 169);
        public static Rectangle HUDHeartSprite = new Rectangle(109, 63, 32, 32);
    }
}
