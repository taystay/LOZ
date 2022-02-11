﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace Sprint2
{
    class LinkUpAttack : ISprite
    {

        private Texture2D linkSprite;
        private int frame;
        private const int maxFrame = 3;
        private const int scale = 3;

        public LinkUpAttack(Texture2D sprite)
        {

            linkSprite = sprite;
            frame = 0;

        }

        public void SetSize(double size)
        {

            //nothing?? for now....
        }


        public void Update(GameTime timer)
        {

            if (timer.TotalGameTime.Milliseconds % 150 == 0)
            {

                frame++;
                
            }

            if (frame == maxFrame)
            {

                frame = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {

            //The code below was taken for the sprite atalas tutorial
            // URL http://rbwhitaker.wikidot.com/monogame-texture-atlases-2 

            //There are only 2 columbs and 1 row
            int frameOneWidth = 16;
            int frameOneHeight = 16;

            int frameTwoWidth = 16;
            int frameTwoHeight = 28;

            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle();

            if (frame == 0)
            {
                sourceRectangle = new Rectangle(60, 30, frameOneWidth, frameOneHeight);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frameOneWidth * scale, frameOneHeight * scale);
            }
            else
            {
                sourceRectangle = new Rectangle(60, 84, frameTwoWidth, frameTwoHeight);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y - (12 * scale), frameTwoWidth * scale, frameTwoHeight * scale);
            }


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}