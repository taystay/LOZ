using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.GameState;
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

		public void Draw(SpriteBatch spriteBatch, Point location) {
            if(Room.Damaged)
                Draw(spriteBatch, location, Color.HotPink);
            else
			    Draw(spriteBatch, location, Color.White);
		}

        public void ChangeScale(double scale) { }

        public virtual void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

            //for SpriteBatch.Begin(...)
            //the paramater idea was from:
            //https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
            //https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, frame, c);

            spriteBatch.End();
        }

    }
}
