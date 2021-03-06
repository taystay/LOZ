using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameStateReference;
using System.Collections.Generic;
using LOZ.LinkClasses.States;
using LOZ.LinkClasses;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkDownAttack : AbstractLinkSprite
    {
        private const int framesPerUpdate = UpdateSpeed.LinkAttack;
        private int frameCounter = 0;
        public LinkDownAttack(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 30, 16, 16));
            frames.Add(new Rectangle(0, 84, 16, 27));
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
                destinationRectangle = new Rectangle((location.X - width / 2), (location.Y - height / 2) + 12, width, height);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.White);
            spriteBatch.End();
        }
    }
}
