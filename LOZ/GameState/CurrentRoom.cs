using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using System.Collections.Generic;
using System.Diagnostics;
using LOZ.LinkClasses;
using LOZ.DungeonClasses;

namespace LOZ.GameState
{
    class CurrentRoom
    {
        private static CurrentRoom instance = new CurrentRoom();
        private int roomCount = 0;
        private int x = 3;
        private int y = 6;
        public Dictionary<Point, DungeonRoom> Rooms { get; set; }
        public Room Room
        {   get
            {
                if (Rooms.ContainsKey(new Point(x, y)))
                    return Rooms[new Point(x, y)];
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

        public void MoveRoomDirection(int dx, int dy)
        {
            ILink previousLink = Room.Link;
            x += dx;
            y += dy;
            if(Room == null)
            {
                x -= dx;
                y -= dy;
            }

            Room.Link = previousLink;
            Room.gameObjects.Add(Room.Link);

            if(dx == 1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + 96, loc.Location.Y + DungeonInfo.DoorToCornerHeight + 48);
            } else if (dx == -1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + loc.Width - 96, loc.Location.Y + DungeonInfo.DoorToCornerHeight + 48);
            }
            else if (dy == 1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + DungeonInfo.DoorToCornerWidth + 48, loc.Location.Y + 96);
            }
            else if (dy == -1)
            {
                Rectangle loc = DungeonInfo.Map;
                Room.Link.Position = new Point(loc.Location.X + DungeonInfo.DoorToCornerWidth + 48, loc.Location.Y + loc.Height -96);
            }
        }

        public Room PreviousRoom()
        {
            roomCount--;
            if (roomCount <= 0)
                roomCount = Rooms.Count-1;
            else
                roomCount--;

            return Room;
        }

        public void Update(GameTime gameTime)
        {
            Room.Update(gameTime);
        }

        public void LoadContent()
        {
            Room.LoadContent();
            if (Room.Link == null)
            {
                Room.Link = new Link(new Point(700, 700));
                Room.gameObjects.Add(Room.Link);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Room.Draw(spriteBatch);
        }
    }
}
