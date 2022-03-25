using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;
using LOZ.Sound;
using LOZ.Hud;
using LOZ.Sound;

namespace LOZ.GameState
{
    class CurrentRoom
    {
        private List<Point3D> roomList = RoomPoints.roomList;
        private static CurrentRoom instance = new CurrentRoom();
        private int roomCount = 0;
        private Point3D coor = new Point3D(3, 6);
        public Dictionary<Point3D, Room> Rooms { get; set; }
        public Room Room
        {   get
            {
                if (Rooms.ContainsKey(coor))
                    return Rooms[coor];
                else
                    return null;
            }
            set { }
        }
        public static CurrentRoom Instance
        {
            get
            {
                return instance;
            }
        }
        private CurrentRoom() { Room.RoomInventory = new Inventory.LinkInventory();  }
        public void LoadTextures(ContentManager Content)
        {
            DisplaySpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            DungeonFactory.Instance.LoadAllTextures(Content);
            SoundManager.Instance.LoadSound(Content);
            Room.hudele = new UserCurrentItemHud(Room.RoomInventory, Content);
        }
        public void Debug()
        {
            Room.DebugMode = !Room.DebugMode;
        }
        public void MoveRoomDirection(int dx, int dy, int dz)
        {
            coor.changeBy(dx, dy, dz);
            if(Room == null)
            {
                coor.changeBy(-dx, -dy, -dz);
                return;
            }

            if (dx == 1) // moved right
                PlaceLink.LeftDungeonDoor();
            else if (dx == -1) // moved left
                PlaceLink.RightDungeonDoor();
            else if (dy == 1) // moved down
                PlaceLink.TopDungeonDoor();
            else if (dy == -1) // moved up
                PlaceLink.BottomDungeonDoor();
            else if (dz == 1)// moved into dungeon
            {
                PlaceLink.PlaceInDungeon();
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Stairs);
            }
            else if (dz == -1) {
                PlaceLink.OutOfDungeon();
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Stairs);
            }
        }
        
        public void NextRoom(int change)
        {
            roomCount += change;
            roomCount = (roomCount % roomList.Count + roomList.Count) % roomList.Count; //https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
            coor = roomList[roomCount];
        }
        public void Update(GameTime gameTime)
        {
            Room.Update(gameTime);
        }
        public void SpawnLink()
        {
            if (Room.Link != null) return;
            Rectangle map = Info.Map;
            Point spawnPoint = new Point(map.Location.X + Info.DoorToCornerWidth + Info.BlockWidth, map.Location.Y + map.Height - Info.DoorWidth);
            Room.Link = new Link(spawnPoint);
            Room.Link.ChangeDirectionUp();                     
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Room.Draw(spriteBatch);
        }
    }
}
