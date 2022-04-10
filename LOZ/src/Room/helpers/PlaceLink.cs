using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.GameState
{
    public static class PlaceLink
    {
        private static Rectangle loc = Info.Map;
        public static void LeftDungeonDoor()
        {
            OldRoom.Link.ChangePosition(new Point(loc.Location.X + Info.DoorWidth, loc.Location.Y + Info.DoorToCornerHeight + Info.BlockWidth));
            OldRoom.Link.ChangeDirectionRight();
        }
        public static void RightDungeonDoor()
        {
            OldRoom.Link.ChangePosition(new Point(loc.Location.X + loc.Width - Info.DoorWidth, loc.Location.Y + Info.DoorToCornerHeight + Info.BlockWidth));
            OldRoom.Link.ChangeDirectionLeft();
        }

        public static void TopDungeonDoor()
        {
            OldRoom.Link.ChangePosition(new Point(loc.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, loc.Location.Y + Info.DoorWidth));
            OldRoom.Link.ChangeDirectionDown();
        }

        public static void BottomDungeonDoor()
        {
            OldRoom.Link.ChangePosition(new Point(loc.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, loc.Location.Y + loc.Height - Info.DoorWidth));
            OldRoom.Link.ChangeDirectionUp();
        }

        public static void PlaceInDungeon()
        {
            OldRoom.Link.ChangePosition(new Point(loc.Location.X + 3 * Info.BlockWidth, loc.Location.Y + Info.BlockWidth));
            OldRoom.Link.ChangeDirectionDown();
        }

        public static void OutOfDungeon()
        {
            OldRoom.Link.ChangePosition(new Point(loc.Location.X + 7 * Info.BlockWidth, loc.Location.Y + 5 * Info.BlockWidth));
            OldRoom.Link.ChangeDirectionLeft();
        }
    }
}
