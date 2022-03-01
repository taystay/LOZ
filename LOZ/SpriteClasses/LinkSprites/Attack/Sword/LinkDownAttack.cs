using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkDownAttack : ISprite
    {

        private Texture2D linkSprite;
        private List<Rectangle> frames;
        private Rectangle frame;
        private int currentFrame;
        private const int maxFrames = 2;
        private const double scale = 3;

        public LinkDownAttack(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 30, 16, 16));
            frames.Add(new Rectangle(0, 84, 16, 27));
        }
        public void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 150 == 0)
                currentFrame++;          
            if (currentFrame == maxFrames)
                currentFrame = 0;
            frame = frames[currentFrame];
        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

            if(currentFrame == 1)
            {
                destinationRectangle = new Rectangle((location.X - width / 2), (location.Y - height / 2) + 12, width, height);
            }

            //for SpriteBatch.Begin(...)
            //the paramater idea was from:
            //https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
            //https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            if (CurrentRoom.Room.Damaged)
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.HotPink);
            else
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.White);

            spriteBatch.End();
        }
    }
}
