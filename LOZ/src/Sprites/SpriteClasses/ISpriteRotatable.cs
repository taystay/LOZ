using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LOZ.SpriteClasses
{
    public abstract class ISpriteRotatable
    {
        public double Scale { get; set; } = 1.0;
        public double FramesPerUpdate { get; set; } = 10;
        public int currentFrame { get; private set; } = 0;
        private int updates = 0;   
        private protected List<Rectangle> frames = new List<Rectangle>();     
        private protected Texture2D _texture;
        public virtual void Update(GameTime gameTime)
        {
            updates++;
            if(updates > FramesPerUpdate)
            {
                updates = 0;
                currentFrame++;
            }
            if (currentFrame >= frames.Count)
                currentFrame = 0;
        }
        public virtual void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, 0.0f);
        public virtual void Draw(SpriteBatch spriteBatch, Point location, float rotation) => Draw(spriteBatch, location, Color.White, rotation);
        public virtual void Draw(SpriteBatch spriteBatch, Point location, Color c) => Draw(spriteBatch, location, c, 0.0f);
        public virtual void Draw(SpriteBatch spriteBatch, Point location, Color c, float rotation)
        {
            Rectangle frameToDraw = frames[currentFrame];
            int width = (int)(frameToDraw.Width * Scale);
            int height = (int)(frameToDraw.Height * Scale);
            var origin = new Vector2(frameToDraw.Width / 2,frameToDraw.Height / 2); //https://stackoverflow.com/questions/31104248/monogame-rotating-a-sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw( 
                _texture,
                new Rectangle(location.X, location.Y, width, height),
                frameToDraw,
                c,
                rotation,
                origin,
                SpriteEffects.None,
                0f
                );
            spriteBatch.End();
        }
    }
}
