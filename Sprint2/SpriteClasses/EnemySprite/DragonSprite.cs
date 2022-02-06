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
        private const int scale = 3;
        private bool facingLeft;

        public DragonSprite(Texture2D sprite)
        {

            dragonSprite = sprite;
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
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Begin();
            spriteBatch.Draw(dragonSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}
