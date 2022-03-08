﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkMovingLeft : AbstractLinkSprite
    {
        public LinkMovingLeft(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(30, 0, 16, 16));
            frames.Add(new Rectangle(30, 30, 16, 16));
        }
        public override void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 150 == 0)
                currentFrame++;
            if (currentFrame == maxFrames)
                currentFrame = 0;
            frame = frames[currentFrame];
        }
    }
}
