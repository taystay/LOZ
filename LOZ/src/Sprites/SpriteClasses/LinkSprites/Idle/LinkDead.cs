using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkDead : AbstractLinkSprite
    {
        private const int framesPerUpdate = 12;
        private int frameCounter = 0;
        public LinkDead(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 120, 16, 16));
            frames.Add(new Rectangle(60, 120, 16, 16));
        }
        public override void Update(GameTime timer)
        {
            
            frameCounter++;
            if (frameCounter > framesPerUpdate) {
                frameCounter = 0;
                currentFrame++;
            }
            if (currentFrame < maxFrames)
                frame = frames[currentFrame];
        }

        public override void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
            if (currentFrame == 1)
            {
                destinationRectangle = new Rectangle((location.X - width / 2), (location.Y - height / 2), width, height);
            }

            //for SpriteBatch.Begin(...)
            //the paramater idea was from:
            //https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
            //https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.White);

            spriteBatch.End();
        }
    }
}
