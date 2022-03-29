using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.GameState
{
    public static class PlaceLink
    {
        private static Rectangle loc = Info.Map;
        public static void LeftDungeonDoor()
        {
            Room.Link.ChangePosition(new Point(loc.Location.X + Info.DoorWidth, loc.Location.Y + Info.DoorToCornerHeight + Info.BlockWidth));
            Room.Link.ChangeDirectionRight();
        }
        public static void RightDungeonDoor()
        {
            Room.Link.ChangePosition(new Point(loc.Location.X + loc.Width - Info.DoorWidth, loc.Location.Y + Info.DoorToCornerHeight + Info.BlockWidth));
            Room.Link.ChangeDirectionLeft();
        }

        public static void TopDungeonDoor()
        {
            Room.Link.ChangePosition(new Point(loc.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, loc.Location.Y + Info.DoorWidth));
            Room.Link.ChangeDirectionDown();
        }

        public static void BottomDungeonDoor()
        {
            Room.Link.ChangePosition(new Point(loc.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, loc.Location.Y + loc.Height - Info.DoorWidth));
            Room.Link.ChangeDirectionUp();
        }

        public static void PlaceInDungeon()
        {
            Room.Link.ChangePosition(new Point(loc.Location.X + 3 * Info.BlockWidth, loc.Location.Y + Info.BlockWidth));
            Room.Link.ChangeDirectionDown();
        }

        public static void OutOfDungeon()
        {
            Room.Link.ChangePosition(new Point(loc.Location.X + 7 * Info.BlockWidth, loc.Location.Y + 5 * Info.BlockWidth));
            Room.Link.ChangeDirectionLeft();
        }
    }
}
