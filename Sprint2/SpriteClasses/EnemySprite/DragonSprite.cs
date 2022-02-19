using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.SpriteClasses.EnemeySprite 
{ 
    class DragonSprite : ISprite
    {

        private Texture2D _texture;
        private int frame = 0;
        private const int maxFrame = 4;
        private const int scale = 2;

        public DragonSprite(Texture2D texture)
        {

            _texture = texture;
        }

        public void Update(GameTime timer)
        {
            if (timer.TotalGameTime.Milliseconds % 100 == 0)
                frame++;
            if (frame == maxFrame)
                frame = 0;

        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {

            //The code below was taken for the sprite atalas tutorial
            // URL http://rbwhitaker.wikidot.com/monogame-texture-atlases-2 

            //There are only 2 columbs and 1 row
            int width = _texture.Width / 2;
            int height = _texture.Height / 5;
            int row = frame/2;
            int column = frame % 2;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width*scale, height*scale);


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();


        }


    }
}
