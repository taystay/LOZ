using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using System.Collections.Generic;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;

namespace LOZ.GameState
{
    class CurrentRoom
    {
        private List<Rectangle> roomList = new List<Rectangle>() 
        { 
            new Rectangle(3,6,0,0),
            new Rectangle(2,6,0,0),
            new Rectangle(4,6,0,0),
            new Rectangle(3,5,0,0),
            new Rectangle(3,4,0,0),
            new Rectangle(4,4,0,0),
            new Rectangle(2,4,0,0),
            new Rectangle(2,3,0,0),
            new Rectangle(3,3,0,0),
            new Rectangle(3,2,0,0),
            new Rectangle(3,1,0,0),
            new Rectangle(2,1,0,0),
            new Rectangle(4,3,0,0),
            new Rectangle(5,3,0,0),
            new Rectangle(5,2,0,0),
            new Rectangle(6,2,0,0),
            new Rectangle(2,1,0,0),
            new Rectangle(1,3,0,0),
            new Rectangle(2,1,1,0),
        };
        private static CurrentRoom instance = new CurrentRoom();
        private int roomCount = 0;
        private int x = 3;
        private int y = 6;
        private int z = 0;
        public Dictionary<Rectangle, Room> Rooms { get; set; }
        public Room Room
        {   get
            {
                if (Rooms.ContainsKey(new Rectangle(x, y, z, 0)))
                    return Rooms[new Rectangle(x, y, z, 0)];
                else
                    return null;
            }
            set
            {
                
            }
        }
        public static CurrentRoom Instance
        {
            get
            {
                return instance;
            }
        }
        private CurrentRoom()
        {

        }
        public void LoadTextures(ContentManager Content)
        {
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            DungeonFactory.Instance.LoadAllTextures(Content);
        }
        public void Debug()
        {
            Room.DEBUGMODE = !Room.DEBUGMODE;

        }
        public void MoveRoomDirection(int dx, int dy, int dz)
        {
            ILink previousLink = Room.Link;
            x += dx;
            y += dy;
            z += dz;
            if(Room == null)
            {
                x -= dx;
                y -= dy;
                z -= dz;
                return;
            }
            Room.Link = previousLink;
            Room.gameObjects.Add(Room.Link);

            if(dx == 1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + 96, loc.Location.Y + DungeonInfo.DoorToCornerHeight + 48);
                Room.Link.ChangeDirectionRight();
            } else if (dx == -1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + loc.Width - 96, loc.Location.Y + DungeonInfo.DoorToCornerHeight + 48);
                Room.Link.ChangeDirectionLeft();
            }
            else if (dy == 1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + DungeonInfo.DoorToCornerWidth + 48, loc.Location.Y + 96);
                Room.Link.ChangeDirectionDown();
            }
            else if (dy == -1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + DungeonInfo.DoorToCornerWidth + 48, loc.Location.Y + loc.Height -96);
                Room.Link.ChangeDirectionUp();
            }
        }
        public void NextRoom()
        {
            ILink previousLink = Room.Link;
            if (roomCount == roomList.Count - 1)
                roomCount = 0;
            else
                roomCount++;

            x = roomList[roomCount].X;
            y = roomList[roomCount].Y;
            z = roomList[roomCount].Width;


            Room.Link = previousLink;
            Room.gameObjects.Add(Room.Link);

        }
        public void PreviousRoom()
        {
            ILink previousLink = Room.Link;
            if (roomCount <= 0)
                roomCount = Rooms.Count - 1;
            else
                roomCount--;

            x = roomList[roomCount].X;
            y = roomList[roomCount].Y;
            z = roomList[roomCount].Width;

            Room.Link = previousLink;
            Room.gameObjects.Add(Room.Link);
        }
        public void Update(GameTime gameTime)
        {
            Room.Update(gameTime);
        }
        public void LoadContent()
        {
            if (Room.Link != null) return;
            Rectangle loc = DungeonInfo.Map;
            Point p = new Point(loc.Location.X + DungeonInfo.DoorToCornerWidth + 48, loc.Location.Y + loc.Height - 96);
            Room.Link = new Link(p);
            Room.Link.ChangeDirectionUp();
            Room.gameObjects.Add(Room.Link);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Room.Draw(spriteBatch);
        }
    }
}
