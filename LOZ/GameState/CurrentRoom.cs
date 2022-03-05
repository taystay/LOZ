using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Diagnostics;
>>>>>>> 68e7e750bb6cc3257a8d740d6aa3ef1c44c0500f
using LOZ.LinkClasses;
using LOZ.DungeonClasses;

namespace LOZ.GameState
{
    class CurrentRoom
    {
        private List<Point> roomList = new List<Point>() 
        { 
            new Point(3,6),
            new Point(2,6),
            new Point(4,6),
            new Point(3,5),
            new Point(3,4),
            new Point(4,4),
            new Point(2,4),
            new Point(2,3),
            new Point(3,3),
            new Point(3,2),
            new Point(3,1),
            new Point(2,1),
            new Point(4,3),
            new Point(5,3),
            new Point(5,2),
            new Point(6,2),
            new Point(2,1),
            new Point(1,3),
        };
        private static CurrentRoom instance = new CurrentRoom();
        private int roomCount = 0;
        private int x = 3;
        private int y = 6;
        public Dictionary<Point, DungeonRoom> Rooms { get; set; }
        private Room dev = new DevRoom();
        public Room Room
        {   get
            {
                if (Rooms.ContainsKey(new Point(x, y)))
                    return Rooms[new Point(x, y)];
                else if (x == 3 && y == 7)
                    return dev;
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
                return;
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

        public void NextRoom()
        {
            if (roomCount == roomList.Count-1)
                roomCount = 0;
            else
                roomCount++;

            x = roomList[roomCount].X;
            y = roomList[roomCount].Y;
        }

        public void PreviousRoom()
        {
            if (roomCount <= 0)
                roomCount = Rooms.Count-1;
            else
                roomCount--;

            x = roomList[roomCount].X;
            y = roomList[roomCount].Y;
        }

        public void Update(GameTime gameTime)
        {
            Room.Update(gameTime);
        }

        public void LoadContent()
        {
            Room.LoadContent();
            dev.LoadContent();
            if (Room.Link == null)
            {
                Rectangle loc = DungeonInfo.Map;
                Point p = new Point(loc.Location.X + DungeonInfo.DoorToCornerWidth + 48, loc.Location.Y + loc.Height - 96);
                Room.Link = new Link(p);
                Room.Link.ChangeDirectionUp();
                Room.gameObjects.Add(Room.Link);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Room.Draw(spriteBatch);
        }
    }
}
