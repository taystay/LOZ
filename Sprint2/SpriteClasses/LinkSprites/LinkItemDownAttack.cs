using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.GameState;
using System.Collections.Generic;

namespace Sprint2.SpriteClasses.LinkSprites
{
    class LinkItemDownAttack : ISprite
    {
        private Texture2D linkSprite;
        private List<Rectangle> frames;
        private Rectangle frame;
        private int currentFrame;
        private const int maxFrames = 2;
        private const double scale = 3;
        public LinkItemDownAttack(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 30, 16, 16));
            frames.Add(new Rectangle(0, 60, 16, 16));
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
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2 - 15, location.Y - height / 2 - 15, width, height);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            if (GameObjects.Instance.Damaged)
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.HotPink);
            else
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.White);

            spriteBatch.End();
        }
    }
}
