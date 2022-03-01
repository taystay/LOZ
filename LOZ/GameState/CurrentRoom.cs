using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;

namespace LOZ.GameState
{
    class CurrentRoom
    {
        private static CurrentRoom instance = new CurrentRoom();
        public static Room Room { get; set; }
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
        }

        public void LoadContent()
        {
            Room.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            Room.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Room.Draw(spriteBatch);
        }
    }
}
