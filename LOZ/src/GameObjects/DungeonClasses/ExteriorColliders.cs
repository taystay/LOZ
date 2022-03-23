using Microsoft.Xna.Framework;
using LOZ.Collision;
using LOZ.GameState;
using System.Collections.Generic;
using LOZ.EnvironmentalClasses;
using LOZ.CommandClasses;
using LOZ.LinkClasses;
using LOZ.ItemsClasses;

namespace LOZ.DungeonClasses
{
    public static class ExteriorColliders
    {
        public static void PlaceColliders(DoorType top, DoorType right, DoorType bottom, DoorType left, List<IGameObjects> objectsInGame)
        {
            if (top != DoorType.Door && top != DoorType.Hole)
            {
                objectsInGame.Add(new InvisibleBlock(Info.singleTopBox));
                if (top == DoorType.Breakable)
                {
                    Rectangle bombSite = Info.topDoorCollider;
                    bombSite.Y += 48;
                    objectsInGame.Insert(0, new DoorCollider(bombSite, new OpenTopDoor(), typeof(Bomb)));
                }
            }     
            else
            {
                objectsInGame.Insert(0,new InvisibleBlock(Info.topHalfBox));
                objectsInGame.Insert(0, new InvisibleBlock(Info.topHalfBox2));
                objectsInGame.Insert(0, new DoorCollider(Info.topDoorCollider, new SwitchRoomUp(), typeof(ILink)));
                objectsInGame.Insert(0, new InvisibleBlock(Info.topDoorCollider));
            }

            if (left != DoorType.Door && left != DoorType.Hole)
                objectsInGame.Insert(0, new InvisibleBlock(Info.singleLeftBox));
            else
            {
                objectsInGame.Insert(0, new InvisibleBlock(Info.leftHalfBox));
                objectsInGame.Insert(0, new InvisibleBlock(Info.leftHalfBox2));
                objectsInGame.Insert(0, new DoorCollider(Info.leftDoorCollider, new SwitchRoomLeft(), typeof(ILink)));
                objectsInGame.Insert(0, new InvisibleBlock(Info.leftDoorCollider));
            }

            if (right != DoorType.Door && right != DoorType.Hole)
                objectsInGame.Insert(0, new InvisibleBlock(Info.singleRightBox));
            else
            {
                objectsInGame.Insert(0, new InvisibleBlock(Info.rightHalfBox));
                objectsInGame.Insert(0, new InvisibleBlock(Info.rightHalfBox2));
                objectsInGame.Insert(0, new DoorCollider(Info.rightDoorCollider, new SwitchRoomRight(), typeof(ILink)));
                objectsInGame.Insert(0, new InvisibleBlock(Info.rightDoorCollider));
            }

            if (bottom != DoorType.Door && bottom != DoorType.Hole)
                objectsInGame.Insert(0, new InvisibleBlock(Info.singleBottomBox));
            else
            {
                objectsInGame.Insert(0, new InvisibleBlock(Info.bottomHalfBox));
                objectsInGame.Insert(0, new DoorCollider(Info.bottomDoorCollider, new SwitchRoomDown(), typeof(ILink)));
                objectsInGame.Insert(0, new InvisibleBlock(Info.bottomDoorCollider));
                objectsInGame.Insert(0, new InvisibleBlock(Info.bottomHalfBox2));
            }
        }

        public static void PlaceDoors(DoorType top, DoorType right, DoorType bottom, DoorType left, List<IGameObjects> doors)
        {
            Point location = new Point(Info.Map.X + Info.DoorToCornerWidth, Info.Map.Y);
            PlaceDoor(location, DoorLocation.Top, top, doors);

            location = new Point(Info.Map.X, Info.Map.Y + Info.DoorToCornerHeight);
            PlaceDoor(location, DoorLocation.Left, left, doors);

            location = new Point(Info.Map.X + Info.DoorToCornerWidth, Info.Map.Y + Info.DungeonHeight - Info.DoorHeight);
            PlaceDoor(location, DoorLocation.Bottom, bottom, doors);

            location = new Point(Info.Map.X + Info.DungeonWidth - Info.DoorWidth, Info.Map.Y + Info.DoorToCornerHeight);
            PlaceDoor(location, DoorLocation.Right, right, doors);
        }
        private static void PlaceDoor(Point location, DoorLocation side, DoorType t, List<IGameObjects> doors)
        {
            switch (t)
            {
                case DoorType.CrackedDoor:
                    doors.Insert(0, new CrackDoor(location, side));
                    break;
                case DoorType.Hole:
                    doors.Insert(0, new HoleWall(location, side));
                    break;
                case DoorType.Wall:
                    doors.Insert(0, new Wall(location, side));
                    break;
                case DoorType.KeyDoor:
                    doors.Insert(0, new KeyDoor(location, side));
                    break;
                case DoorType.Breakable:
                    doors.Insert(0, new Wall(location, side));
                    break;
                default:
                    doors.Insert(0, new DoorObject(location, side));
                    break;
            }
        }
    }
}
