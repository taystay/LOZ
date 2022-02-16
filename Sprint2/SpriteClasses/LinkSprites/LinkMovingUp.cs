using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.GameState;

namespace Sprint2.SpriteClasses.LinkSprites
{
    class LinkMovingUp : ISprite
    {

        private Texture2D linkSprite;
        //private List<Rectangle> frames;
        private int frame;
        private const int maxFrame = 2;
        private const int scale = 3;
        public LinkMovingUp(Texture2D sprite)
        {
            linkSprite = sprite;
            frame = 0;
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
            int width =  (linkSprite.Width / 4);
            int height = (linkSprite.Height / 4);
            int row = frame;
            int column = 2;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            if (GameObjects.Instance.Damaged)
            {
                spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.HotPink);
            }
            else
            {
                spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();


        }


    }
}
