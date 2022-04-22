using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameStateReference;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkItemLeftAttack : AbstractLinkSprite
    {
        private const int framesPerUpdate = UpdateSpeed.LinkAttack;
        private int frameCounter = 0;
        public LinkItemLeftAttack(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(30, 30, 16, 16));
            frames.Add(new Rectangle(30, 60, 16, 16));
        }

        public override void Update(GameTime timer)
        {
            frameCounter++;
            if (frameCounter > framesPerUpdate)
            {
                currentFrame++;
                frameCounter = 0;
            }               
            if (currentFrame == maxFrames)
            {
                currentFrame = 0;
            }
            frame = frames[currentFrame];
        }
    }
}
