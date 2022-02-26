﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.EnemeySprite 
{ 
    class SkeletonSprite : ISprite
    {

        private Texture2D skeletonSprite;
        private int frame = 0;
        private const int maxFrame = 2;
        private const int scale = 1;

        public SkeletonSprite(Texture2D sprite)
        {
            skeletonSprite = sprite;             
        }

        public void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 200 == 0)
                frame++;
            if (frame == maxFrame)
                frame = 0;
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
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width*scale, height*scale);

            //for SpriteBatch.Begin(...)
            //the paramater idea was from:
            //https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
            //https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(skeletonSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}