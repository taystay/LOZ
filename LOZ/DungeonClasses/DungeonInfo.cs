using Microsoft.Xna.Framework;

namespace LOZ.DungeonClasses
{
    public static class DungeonInfo
    {
        public const int DoorToCornerWidth = 336;
        public const int DoorToCornerHeight = 216;
        public const int DoorWidth = 96;
        public const int DoorHeight = 96;
        public const int DungeonWidth = 768;
        public const int DungeonHeight = 528;
        public static Rectangle Map { get; set; }
        public static Rectangle Inside { get; set; }
    }
}
