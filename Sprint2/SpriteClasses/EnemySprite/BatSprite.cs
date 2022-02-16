using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.EnemeySprite
{
    class BatSprite : ISprite
    {

        private Texture2D _texture;
        private int frame = 0;
        private const int maxFrame = 2;
        private const double scale = 1.0;

        public BatSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 150 == 0)
                frame++;
            if (frame == maxFrame)
                frame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {

            //The code below was taken for the sprite atalas tutorial
            // URL http://rbwhitaker.wikidot.com/monogame-texture-atlases-2 

            //There are only 2 columbs and 1 row
            int width =  (_texture.Width / 2);
            int height = (_texture.Height / 5);
            int row = 4;
            int column = frame % 2;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X - (int)(width * scale) / 2, location.Y - (int)(height * scale) /2, (int)(width*scale), (int)(height*scale));


            spriteBatch.Begin();
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}
