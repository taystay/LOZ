using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.Inventory;
using LOZ.Collision;
using LOZ.Room;
using LOZ.Sound;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.GameStateReference
{
    public static class RoomReference
    {
        private static bool HardMode = false;
        public static bool GetHardMode() => HardMode;
        public static void ToggleHardMode() => HardMode = !HardMode;
        public static ILink GetLink() => CurrentRoom.link;
        public static void SetLink(ILink linkState) => CurrentRoom.link = linkState;
        public static Point3D GetCurrLocation() => CurrentRoom.currentLocation;

        public static LinkInventory GetInventory() => CurrentRoom.link.Inventory;
        public static bool GetDebug() => CurrentRoom.DebugMode;
        public static void ToggleDebug() => CurrentRoom.DebugMode = !CurrentRoom.DebugMode;
        public static List<Point3D> GetRooms() => CurrentRoom.Instance.GetRoomCoor();

        public static Dictionary<Point3D, IRoom> GetAllRooms() => CurrentRoom.Instance._allRooms;
        public static void AddItem(IGameObjects obj) => CurrentRoom.Instance.AddItemToRoom(obj);
        public static void NextRoom(int change) => CurrentRoom.Instance.NextRoom(change);
        
        public static IRoom GetCurrRoom() => CurrentRoom.Instance.currentRoom;
        public static List<IGameObjects> GetObjectsList() => CurrentRoom.Instance.currentRoom.GetObjectsList();
        public static IRoom GetChangeRoom(int dx, int dy, int dz)
        {
            Point3D currentRoom = CurrentRoom.currentLocation;
            Point3D nextRoom = new Point3D(currentRoom.X + dx, currentRoom.Y + dy, currentRoom.Z + dz);
            if (!CurrentRoom.Instance._allRooms.ContainsKey(nextRoom)) return null;
            return CurrentRoom.Instance._allRooms[nextRoom];
        }
        public static void SetAbsoluteRoom(int x, int y, int z)
        {
            Point3D currentRoom = CurrentRoom.currentLocation;
            int dx = -currentRoom.X + x;
            int dy = -currentRoom.Y + y;
            int dz = -currentRoom.Z + z;
            if (GetChangeRoom(dx, dy, dz) == null) return;
            SetLinkPosition(dx, dy, dz);
            SetRoomLocation(dx, dy, dz);
        }
        public static void SetLinkPosition(int dx, int dy, int dz)
        {
            if (dx != 0)
                GetChangeRoom(dx, dy, dz).PlaceLinkX(dx);
            if(dy != 0)
                GetChangeRoom(dx, dy, dz).PlaceLinkY(dy);
            if (dz != 0)
            {
                GetChangeRoom(dx, dy, dz).PlaceLinkZ(dz);
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Stairs);
            }           
            CurrentRoom.link.Idle();
        }
        public static void SetRoomLocation(int x, int y, int z) {
            
            Point3D currentRoom = CurrentRoom.currentLocation;
            Point3D nextRoom = new Point3D(currentRoom.X + x, currentRoom.Y + y, currentRoom.Z + z);
            if (!CurrentRoom.Instance._allRooms.ContainsKey(nextRoom)) return;
            CurrentRoom.Instance.currentRoom = GetChangeRoom(x, y, z);
            CurrentRoom.currentLocation = nextRoom;
            CurrentRoom.Instance.currentRoom = CurrentRoom.Instance._allRooms[nextRoom];
        }
        public static void SetRoomLocationPoint(Point3D location)
        {
            CurrentRoom.Instance.currentRoom = CurrentRoom.Instance._allRooms[location];
            CurrentRoom.currentLocation = location;
        }
        public static void DrawOffset(SpriteBatch spriteBatch, Point offSet) => CurrentRoom.Instance.DrawOffset(spriteBatch, offSet);
        public static void Draw(SpriteBatch spriteBatch) => CurrentRoom.Instance.Draw(spriteBatch);
    }
}
