using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.GameState;

namespace Sprint2.SpriteClasses.LinkSprites
{
    class LinkUpIdle : ISprite
    {
        private Texture2D linkSprite;
        private Rectangle frame;
        private const double scale = 3;
        public LinkUpIdle(Texture2D sprite)
        {
            linkSprite = sprite;
            frame = new Rectangle(2 * linkSprite.Width / 4, 0, linkSprite.Width / 4, linkSprite.Height / 4);
        }

        public void Update(GameTime timer)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            if (GameObjects.Instance.Damaged)
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.HotPink);
            else
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.White);

            spriteBatch.End();
        }
    }
}
