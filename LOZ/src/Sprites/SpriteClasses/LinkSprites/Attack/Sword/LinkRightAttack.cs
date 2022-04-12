using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameStateReference;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkRightAttack : AbstractLinkSprite
    {
        private const int framesPerUpdate = 500;
        private int frameCounter = 0;
        public LinkRightAttack(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(90, 30, 16, 16));
            frames.Add(new Rectangle(84, 90, 28, 16));
        }
        public override void Update(GameTime timer)
        {
            
            frameCounter++;
            if (frameCounter > framesPerUpdate) {
                frameCounter = 0;
                currentFrame++;
            }
            if (currentFrame == maxFrames)
            {
                RoomReference.GetLink().Idle();
                currentFrame = 0;
            }
            frame = frames[currentFrame];
        }
        public override void Draw(SpriteBatch spriteBatch, Point location, Color c)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

            if (currentFrame == 1)
            {
                destinationRectangle = new Rectangle((location.X - width / 2) + 12, (location.Y - height / 2), width, height);
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
