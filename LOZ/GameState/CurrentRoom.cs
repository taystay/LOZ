using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using System.Collections.Generic;
using System.Diagnostics;


namespace LOZ.GameState
{
    class CurrentRoom
    {
        private static CurrentRoom instance = new CurrentRoom();
        private int roomCount = 0;
        
        public List<Room> Rooms { get; set; }
        public Room Room
        {   get
            {
                return Rooms[roomCount];
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
            Rooms[roomCount].DEBUGMODE = !Rooms[roomCount].DEBUGMODE;
        }
        public Room NextRoom()
        {
            Room = Rooms[roomCount];
            if (roomCount == Rooms.Count-1)
                roomCount = 0;
            else
                roomCount++;

            return Room;
        }

        public Room PreviousRoom()
        {
            Room = Rooms[roomCount];
            roomCount--;
            if (roomCount <= 0)
                roomCount = Rooms.Count-1;
            else
                roomCount--;

            return Room;
        }

        public void Update(GameTime gameTime)
        {
            Rooms[roomCount].Update(gameTime);
        }

        public void LoadContent()
        {
            Rooms[roomCount].LoadContent();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rooms[roomCount].Draw(spriteBatch);
        }
    }
}
