﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.GameState;
using System.Collections.Generic;

namespace Sprint2.SpriteClasses.LinkSprites
{
    class LinkDownAttack : ISprite
    {

        private Texture2D linkSprite;
        private List<Rectangle> frames;
        private Rectangle frame;
        private int frame2;
        private const int maxFrame = 2;
        private const int scale = 3;

        public LinkDownAttack(Texture2D sprite)
        {
            linkSprite = sprite;
            frame2 = 0;
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 30, 16, 16));
            frames.Add(new Rectangle(0, 84, 16, 27));
        }
        public void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 150 == 0)
                frame2++;          
            if (frame2 == maxFrame)
                frame2 = 0;
            frame = frames[frame2];
        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            //Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X, location.Y, width, height);


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            if (GameObjects.Instance.Damaged)
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.HotPink);
            else
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.White);

            spriteBatch.End();


        }


    }
}
