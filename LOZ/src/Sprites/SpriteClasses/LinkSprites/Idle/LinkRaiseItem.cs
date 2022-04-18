using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkRaiseItem : AbstractLinkSprite
    {
        private const int framesPerUpdate = 10;
        private int frameCounter = 0;
        public LinkRaiseItem(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 120, 16, 16));
            frames.Add(new Rectangle(30, 120, 16, 16));
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
            frame = frames[1];
        }
    }
}
