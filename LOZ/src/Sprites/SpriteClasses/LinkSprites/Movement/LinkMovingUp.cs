using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkMovingUp : AbstractLinkSprite
    {
        private const int framesPerUpdate = UpdateSpeed.LinkWalk;
        private int frameCounter = 0;
        public LinkMovingUp(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(60, 0, 16, 16));
            frames.Add(new Rectangle(60, 30, 16, 16));
        }
        public override void Update(GameTime timer)
        {           
            frameCounter++;
            if (frameCounter > framesPerUpdate) {
                frameCounter = 0;
                currentFrame++;
            }
            if (currentFrame == maxFrames)
                currentFrame = 0;
            frame = frames[currentFrame];
        }
    }
}
