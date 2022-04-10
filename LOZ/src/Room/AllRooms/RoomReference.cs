using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.Inventory;
using LOZ.Collision;
using LOZ.Room;
using LOZ.Sound;

namespace LOZ.GameStateReference
{
    public static class RoomReference
    {
        public static ILink GetLink()
        {
            return CurrentRoom.link;
        }
        public static void SetLink(ILink linkState)
        { 
            CurrentRoom.link = linkState;
        }
        public static Point3D GetCurrLocation()
        {
            return CurrentRoom.currentLocation;
        }
        public static LinkInventory GetInventory()
        {
            return CurrentRoom.link.Inventory;
        }
        public static bool GetDebug()
        {
            return CurrentRoom.DebugMode;
        }
        public static void ToggleDebug()
        {
            CurrentRoom.DebugMode = !CurrentRoom.DebugMode;
        }
        public static void SetChangeRoom()
        {
            CurrentRoom.changeRoom = true;
        }
        public static bool GetChangeRoom()
        {
            return CurrentRoom.changeRoom;
        }
        public static List<Point3D> GetRooms()
        {
            return CurrentRoom.Instance.GetRoomCoor();
        }
        public static Dictionary<Point3D, IRoom> GetAllRooms()
        {
            return CurrentRoom.Instance._allRooms;
        }
        public static void AddItem(IGameObjects obj)
        {
            CurrentRoom.Instance.AddItemToRoom(obj);
        }
        public static void NextRoom(int change)
        {
            CurrentRoom.Instance.NextRoom(change);
        }
        public static IRoom GetCurrRoom()
        {
            return CurrentRoom.Instance.currentRoom;
        }
        public static List<IGameObjects> GetObjectsList()
        {
            return CurrentRoom.Instance.currentRoom.GetObjectsList();
        }
        public static void SetRoomLocation(int x, int y, int z) {

            if (CurrentRoom.Instance._allRooms.ContainsKey(CurrentRoom.currentLocation + new Point3D(x, y, z))) return;
            if (x != 0 && (y != 0 || z != 0)) return;
            if (y != 0 && (z != 0 || z != 0)) return;
            if (z != 0 && (y != 0 || x != 0)) return;
            if (x > 1 || x < -1) return;
            if (y > 1 || y < -1) return;
            if (z > 1 || z < -1) return;
            CurrentRoom.currentLocation.X += x;
            CurrentRoom.currentLocation.Y += y;
            CurrentRoom.currentLocation.Z += z;

            if (x == 1) // moved right
                PlaceLink.LeftDungeonDoor();
            else if (x == -1) // moved left
                PlaceLink.RightDungeonDoor();
            else if (y == 1) // moved down
                PlaceLink.TopDungeonDoor();
            else if (y == -1) // moved up
                PlaceLink.BottomDungeonDoor();
            else if (z == 1)// moved into dungeon
            {
                PlaceLink.PlaceInDungeon();
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Stairs);
            }
            else if (z == -1)
            {
                PlaceLink.OutOfDungeon();
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Stairs);
            }
        }
        public static void SetRoomLocationPoint(Point3D location)
        {

            CurrentRoom.currentLocation = location;
        }
    }
}
