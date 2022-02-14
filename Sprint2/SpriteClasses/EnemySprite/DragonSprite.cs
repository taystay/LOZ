using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace Sprint2
{
    class DragonSprite : ISprite
    {

        private Texture2D dragonSprite;
        //private List<Rectangle> frames;
        private int frame;
        private const int maxFrame = 4;
        private double scale;

        public DragonSprite(Texture2D sprite)
        {

            dragonSprite = sprite;
            frame = 0;
            scale = 2;
        }

        public void SetSize(double size)
        {

            scale = size;
        }


        public void Update(GameTime timer)
        {

            if (timer.TotalGameTime.Milliseconds % 100 == 0)
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
            int width = dragonSprite.Width / 2;
            int height = dragonSprite.Height / 5;
            int row = frame/2;
            int column = frame % 2;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X, location.Y, (int)(width * scale), (int)(height * scale));


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(dragonSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}
