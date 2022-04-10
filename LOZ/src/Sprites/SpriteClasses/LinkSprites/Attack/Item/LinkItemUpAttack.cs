﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameStateReference;
using System.Collections.Generic;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkItemUpAttack : AbstractLinkSprite
    {

        public LinkItemUpAttack(Texture2D sprite)
        {
            linkSprite = sprite;
            currentFrame = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(60, 30, 16, 16));
            frames.Add(new Rectangle(60, 60, 16, 16));
        }
        public override void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 150 == 0)
                currentFrame++;
            if (currentFrame == maxFrames)
            {
                currentFrame = 0;
                RoomReference.GetLink().Idle();
            }
            frame = frames[currentFrame];
        }
    }
}
