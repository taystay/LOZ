using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;
using LOZ.Sound;
using LOZ.Hud;
using LOZ.ItemsClasses;
using LOZ.SpriteClasses;

namespace LOZ.GameState
{
    class CurrentRoom
    {
        public List<Point3D> roomList { get; set; } = RoomPoints.roomList;
        private static CurrentRoom instance = new CurrentRoom();
        private int roomCount = 0;
        private Point3D coor = new Point3D(3, 6);
        public bool transition { get; set; } = false;
        private float alpha = 0.0f;
        private Texture2D fade;
        private int dx = 0, dy = 0, dz = 0;
        
        public Point3D linkCoor { 
            get
            {
                return coor;
            }
            set
            {
                coor = value;
            }
        }
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
        private CurrentRoom() {
            Room.RoomInventory = new Inventory.LinkInventory();
            
        }
        public void LoadTextures(ContentManager Content)
        {
            DisplaySpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            DungeonFactory.Instance.LoadAllTextures(Content);
            GameFont.Instance.LoadAllTextures(Content);
            Room.hudele = new UserCurrentItemHud(Room.RoomInventory, Content);
            fade = Content.Load<Texture2D>("Black");
            
        }
        public void Debug()
        {
            Room.DebugMode = !Room.DebugMode;
        }
        public void Transition(int dx, int dy, int dz)
        {
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;
            if (!transition)
            {
                transition = true;
            }
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
            
            if (!transition)
            {
                Room.Update(gameTime);
                Room roomevent1 = Rooms[new Point3D(2, 4)];
                Room roomevent2 = Rooms[new Point3D(5, 2)];
                if (!roomevent1.HasEnemies)
                    roomevent1.exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
                if (!roomevent2.HasEnemies)
                    roomevent2.exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);

                    
            } else
            {
                if(alpha <= 1.0f)
                {
                    alpha += 0.05f;
                }
                else
                {
                    MoveRoomDirection(dx, dy, dz);
                    alpha = 0.1f;
                    transition = false;
                }
            }
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
            if (transition)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
                spriteBatch.Draw(fade, new Rectangle(0, 0, Info.screenWidth, Info.screenHeight), Color.White * alpha);
                spriteBatch.End();
            }
            
        }
    }
}
