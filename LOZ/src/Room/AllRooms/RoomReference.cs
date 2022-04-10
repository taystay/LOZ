using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.Inventory;
using LOZ.Collision;

namespace LOZ.Room
{
    public static class RoomReference
    {
        public static ILink GetLink()
        {
            return CurrentRoom.link;
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
    }
}
