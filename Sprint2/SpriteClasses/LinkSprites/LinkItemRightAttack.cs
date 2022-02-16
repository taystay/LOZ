using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.GameState;

namespace Sprint2.SpriteClasses.LinkSprites
{
    class LinkItemRightAttack : ISprite
    {

        private Texture2D linkSprite;
        private int frame;
        private const int maxFrame = 3;
        private const int scale = 3;
        public LinkItemRightAttack(Texture2D sprite)
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

            //There are only 2 columns and 1 row
            int frameOneWidth = 16;
            int frameOneHeight = 16;

            int frameTwoWidth = 16;
            int frameTwoHeight = 16;

            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle();

            if (frame == 0)
            {
                sourceRectangle = new Rectangle(90, 30, frameOneWidth, frameOneHeight);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frameOneWidth * scale, frameOneHeight * scale);
            }
            else
            {
                sourceRectangle = new Rectangle(90, 60, frameTwoWidth, frameTwoHeight);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frameTwoWidth * scale, frameTwoHeight * scale);
            }


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
