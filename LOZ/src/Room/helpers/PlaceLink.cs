using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    public static class PlaceLink
    {
        private static Rectangle loc = Info.Map;
        public static void LeftDungeonDoor()
        {
            CurrentRoom.link.ChangePosition(new Point(loc.Location.X + Info.DoorWidth, loc.Location.Y + Info.DoorToCornerHeight + Info.BlockWidth));
            CurrentRoom.link.ChangeDirectionRight();
        }
        public static void RightDungeonDoor()
        {
            CurrentRoom.link.ChangePosition(new Point(loc.Location.X + loc.Width - Info.DoorWidth, loc.Location.Y + Info.DoorToCornerHeight + Info.BlockWidth));
            CurrentRoom.link.ChangeDirectionLeft();
        }
        public static void TopDungeonDoor()
        {
            CurrentRoom.link.ChangePosition(new Point(loc.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, loc.Location.Y + Info.DoorWidth));
            CurrentRoom.link.ChangeDirectionDown();
        }
        public static void BottomDungeonDoor()
        {
            CurrentRoom.link.ChangePosition(new Point(loc.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, loc.Location.Y + loc.Height - Info.DoorWidth));
            CurrentRoom.link.ChangeDirectionUp();
        }
        public static void PlaceInDungeon()
        {
            CurrentRoom.link.ChangePosition(new Point(loc.Location.X + 3 * Info.BlockWidth, loc.Location.Y + Info.BlockWidth));
            CurrentRoom.link.ChangeDirectionDown();
        }
        public static void OutOfDungeon()
        {
            CurrentRoom.link.ChangePosition(new Point(loc.Location.X + 7 * Info.BlockWidth, loc.Location.Y + 5 * Info.BlockWidth));
            CurrentRoom.link.ChangeDirectionLeft();
        }
    }
}
