using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.GameStateReference;
using System.Collections.Generic;

namespace LOZ.SpriteClasses
{
    abstract class AbstractLinkSprite : ISprite
    {
        private protected Texture2D linkSprite;
        private protected List<Rectangle> frames;
        private protected Rectangle frame;
        private protected int currentFrame;
        private protected int maxFrames = 2;
        private protected double scale = 3;
        public abstract void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch, Point location) => Draw(spriteBatch, location, Color.White);
        public void ChangeScale(double scale) { }
        public virtual void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, frame, c);
            spriteBatch.End();
        }

    }
}
