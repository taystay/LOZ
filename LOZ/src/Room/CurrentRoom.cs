using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;
using LOZ.Collision;
using System.Linq;

namespace LOZ.Room
{
    class CurrentRoom
    {
        #region protectedVar
        internal static ILink link { get; set; }
        internal static Point3D currentLocation;
        internal static bool changeRoom;
        internal static bool DebugMode { get; set; }
        internal Dictionary<Point3D, IRoom> _allRooms { get; set; }
        internal IRoom currentRoom;
        #endregion

        #region privateVar
        private static CurrentRoom instance = new CurrentRoom();
        private List<Point3D> coorRoom = new List<Point3D>();
        //private bool transition = false;
        private int roomCount = 0;
        #endregion
        public static CurrentRoom Instance {
            get {
                return instance;
            }
        }
        private CurrentRoom() { }
        public void LoadContents(Dictionary<Point3D, IRoom> rooms) {
            _allRooms = rooms;
            currentLocation = new Point3D(3, 6, 0);
            changeRoom = false;
            currentRoom = _allRooms[currentLocation];//https://stackoverflow.com/questions/1276763/how-do-i-get-the-list-of-keys-in-a-dictionary
            coorRoom = _allRooms.Keys.ToList();

            Point spawnPoint = new Point(Info.Map.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, Info.Map.Location.Y + Info.Map.Height - Info.DoorWidth - 24);
            link = new Link(spawnPoint);
        }
        public void Update(GameTime gameTime) {

            ChangeRoom();
            currentRoom.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch) {
            if (DebugMode)
            {
                Factories.GameFont.Instance.Write(spriteBatch, "x: " + currentLocation.X + ",y: " + currentLocation.Y + ",z: " + currentLocation.Z, 300, 200);
                Factories.GameFont.Instance.Write(spriteBatch, "mouse: {x}: " + Mouse.GetState().X + " {y}: " + Mouse.GetState().Y, 300, 250);
            }
                
            currentRoom.Draw(spriteBatch, new Point(0,0));
        }
        public void DrawOffset(SpriteBatch spriteBatch, Point offset) {       
            currentRoom.Draw(spriteBatch, offset);
        }
        private void ChangeRoom() {
            //change currentLocation and then change rooms if necessary
            if (changeRoom)
            {
                currentRoom = _allRooms[currentLocation];
                changeRoom = false;
            }
        }
        internal List<Point3D> GetRoomCoor()
        {
            return _allRooms.Keys.ToList(); //https://stackoverflow.com/questions/1276763/how-do-i-get-the-list-of-keys-in-a-dictionary
        }
        internal void AddItemToRoom(IGameObjects item) {
            currentRoom.AddItem(item);
        }
        internal void NextRoom(int change)
        {
            roomCount += change;
            roomCount = (roomCount % _allRooms.Count + _allRooms.Count) % _allRooms.Count; //https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
            currentRoom = _allRooms[coorRoom[roomCount]];
            currentLocation = coorRoom[roomCount];
        }
    }
}
