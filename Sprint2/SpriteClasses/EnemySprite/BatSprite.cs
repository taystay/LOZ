﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace Sprint2
{
    class BatSprite : ISprite
    {

        private Texture2D batSprite;
        private int frame;
        private const int maxFrame = 2;
        private double scale;

        public BatSprite(Texture2D sprite)
        {
            batSprite = sprite;
            frame = 0;
            scale = 2;
        }

        public void SetSize(double size)
        {

            scale = size; 
        }


        public void Update(GameTime timer)
        {

            if (timer.TotalGameTime.Milliseconds % 150 == 0)
            {

                frame++;
                if (frame == maxFrame)
                {

                    frame = 0;
                }

            }

        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {

            //The code below was taken for the sprite atalas tutorial
            // URL http://rbwhitaker.wikidot.com/monogame-texture-atlases-2 

            //There are only 2 columbs and 1 row
            int width =  (batSprite.Width / 2);
            int height = (batSprite.Height / 5);
            int row = 4;
            int column = frame % 2;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X, location.Y, (int)(width*scale), height);


            spriteBatch.Begin();
            spriteBatch.Draw(batSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}
