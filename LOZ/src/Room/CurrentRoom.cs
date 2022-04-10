using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;
using LOZ.Collision;

namespace LOZ.Room
{
    class CurrentRoom
    {
        #region publicVar
        public static ILink link { get; set; }
        public static Point3D currentLocation;
        public static bool changeRoom;
        public static bool DebugMode { get; set; }
        public Dictionary<Point3D, IRoom> _allRooms { get; set; }
        #endregion

        #region privateVar
        private IRoom currentRoom;
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
            currentRoom = _allRooms[currentLocation];

            
            Point spawnPoint = new Point(Info.Map.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, Info.Map.Location.Y + Info.Map.Height - Info.DoorWidth);
            link = new Link(spawnPoint);
        }
        public void Update(GameTime gameTime) {

            ChangeRoom();
            currentRoom.Update(gameTime);

        }
<<<<<<< HEAD
        public void Draw(SpriteBatch spriteBatch, ILink link) {

            currentRoom.Draw(spriteBatch, new Point(0,0));
=======

        public void Draw(SpriteBatch spriteBatch) {

            currentRoom.Draw(spriteBatch, new Point(0,0));
        }


        public void DrawOffset(SpriteBatch spriteBatch, Point offset) {

            currentRoom.Draw(spriteBatch, offset);
>>>>>>> 733b1ba9eae2ce769718a3ac4ac45c87fe450639
        }
        private void ChangeRoom() {
            //change currentLocation and then change rooms if necessary
            if (changeRoom) 
                currentRoom = _allRooms[currentLocation];
            changeRoom = false;   
        }
        public List<Point3D> GetRoomCoor()
        {
            //List<Point3D> coorRoom = new List<Point3D>();
            foreach (KeyValuePair<Point3D, IRoom> room in _allRooms)
            {
                coorRoom.Add(room.Key);
            }
            return coorRoom;
        }

        public void AddItemToRoom(IGameObjects item) {
            currentRoom.AddItem(item);
        }

        public void NextRoom(int change)
        {
            roomCount += change;
            roomCount = (roomCount % _allRooms.Count + _allRooms.Count) % _allRooms.Count; //https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
            currentRoom = _allRooms[coorRoom[roomCount]];
        }









        //public List<Point3D> roomList { get; set; } = RoomPoints.roomList;
        //private static CurrentRoom instance = new CurrentRoom();
        //private int roomCount = 0;
        //private Point3D coor = new Point3D(3, 6);
        //public bool transition { get; set; } = false;
        //private float alpha = 0.0f;
        //private Texture2D fade;
        //private int dx = 0, dy = 0, dz = 0;

        //public Point3D linkCoor { get; set; }
        //public Dictionary<Point3D, OldRoom> Rooms { get; set; }
        //public OldRoom Room
        //{   get
        //    {
        //        if (Rooms.ContainsKey(coor))
        //            return Rooms[coor];
        //        else
        //            return null;
        //    }
        //    set { }
        //}
        //public static CurrentRoom Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}
        //private CurrentRoom() {
        //    OldRoom.RoomInventory = new Inventory.LinkInventory();                  
        //}
        //public void LoadTextures(ContentManager Content)
        //{        
        //    fade = Content.Load<Texture2D>("Black");
        //    OldRoom.RoomInventory.Initialize();

        //}
        //public void Debug()
        //{
        //    OldRoom.DebugMode = !OldRoom.DebugMode;
        //}
        //public void Transition(int dx, int dy, int dz)
        //{
        //    this.dx = dx;
        //    this.dy = dy;
        //    this.dz = dz;
        //    if (!transition)
        //    {
        //        transition = true;
        //    }
        //}
        //public void MoveRoomDirection(int dx, int dy, int dz)
        //{
        //    coor.changeBy(dx, dy, dz);
        //    if (Room == null)
        //    {
        //        coor.changeBy(-dx, -dy, -dz);
        //        return;
        //    }

        //    if (dx == 1) // moved right
        //        PlaceLink.LeftDungeonDoor();
        //    else if (dx == -1) // moved left
        //        PlaceLink.RightDungeonDoor();
        //    else if (dy == 1) // moved down
        //        PlaceLink.TopDungeonDoor();
        //    else if (dy == -1) // moved up
        //        PlaceLink.BottomDungeonDoor();
        //    else if (dz == 1)// moved into dungeon
        //    {
        //        PlaceLink.PlaceInDungeon();
        //        SoundManager.Instance.SoundToPlayInstance(SoundEnum.Stairs);
        //    }
        //    else if (dz == -1)
        //    {
        //        PlaceLink.OutOfDungeon();
        //        SoundManager.Instance.SoundToPlayInstance(SoundEnum.Stairs);
        //    }
        //}
        //public void NextRoom(int change)
        //{
        //    roomCount += change;
        //    roomCount = (roomCount % roomList.Count + roomList.Count) % roomList.Count; //https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
        //    coor = roomList[roomCount];
        //}
        //public void Update(GameTime gameTime)
        //{

        //    if (!transition)
        //    {
        //        Room.Update(gameTime);
        //        OldRoom roomevent1 = Rooms[new Point3D(2, 4)];
        //        OldRoom roomevent2 = Rooms[new Point3D(5, 2)];
        //        if (!roomevent1.HasEnemies)
        //            roomevent1.exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
        //        if (!roomevent2.HasEnemies)
        //            roomevent2.exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);


        //    } else
        //    {
        //        if(alpha <= 1.0f)
        //        {
        //            alpha += 0.05f;
        //        }
        //        else
        //        {
        //            MoveRoomDirection(dx, dy, dz);
        //            alpha = 0.1f;
        //            transition = false;
        //        }
        //    }
        //}
        //public void SpawnLink()
        //{
        //    if (OldRoom.Link != null) return;
        //    Rectangle map = Info.Map;
        //    Point spawnPoint = new Point(map.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, map.Location.Y + map.Height - Info.DoorWidth);
        //    OldRoom.Link = new Link(spawnPoint);
        //    OldRoom.Link.ChangeDirectionUp();                     
        //}
        //public void Draw(SpriteBatch spriteBatch)
        //{

        //    Draw(spriteBatch, new Point());

        //}

        //public void Draw(SpriteBatch spriteBatch, Point offset)
        //{

        //    Room.Draw(spriteBatch, offset);
        //    if (transition)
        //    {
        //        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
        //        spriteBatch.Draw(fade, new Rectangle(0, 0, Info.screenWidth, Info.screenHeight), Color.White * alpha);
        //        spriteBatch.End();
        //    }

        //}
    }
}
