using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkMovingDown : AbstractLinkSprite
    {
        private const int framesPerUpdate = UpdateSpeed.LinkWalk;
        private int frameCounter = 0;
        public LinkMovingDown(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 0, 16, 16));
            frames.Add(new Rectangle(0, 30, 16, 16));
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
