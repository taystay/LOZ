using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkDead : AbstractLinkSprite
    {
        private const int framesPerUpdate = 10;
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
    }
}
