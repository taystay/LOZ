﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace Sprint2
{
    class SkeletonSprite : ISprite
    {

        private Texture2D skeletonSprite;
        /*private List<Rectangle> frameList;
        private Rectangle currentFrame;*/
        private int frame;
        private const int maxFrame = 2;
        private const int scale = 3;

        public SkeletonSprite(Texture2D sprite)
        {

            skeletonSprite = sprite;
         /*   frameList = new List<Rectangle>();
            frameList.Add(new Rectangle(0, 192, 49, 65));
            frameList.Add(new Rectangle(49, 192, 49, 65));*/
            frame = 0;
            //currentFrame = frameList[frame];
               
        }

        public void SetSize(double size)
        {

            //nothing?? for now....
        }


        public void Update(GameTime timer)
        {

            if (timer.TotalGameTime.Milliseconds % 200 == 0)
            {

                frame++;
                if (frame == maxFrame)
                {
                    frame = 0;
                    
                }
                //currentFrame = frameList[frame];

            }

        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {

            //The code below was taken for the sprite atalas tutorial
            // URL http://rbwhitaker.wikidot.com/monogame-texture-atlases-2 

            //There are only 2 columbs and 1 row
            int width = skeletonSprite.Width/2;
            int height = skeletonSprite.Height/5;
            int row = 3;
            int column = frame % 2;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X, location.Y, width, height);

            
            spriteBatch.Begin();
            spriteBatch.Draw(skeletonSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}
