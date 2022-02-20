using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.GameState;

namespace Sprint2.SpriteClasses.LinkSprites
{
    class LinkLeftIdle : ISprite
    {
        private Texture2D linkSprite;
        private Rectangle frame;
        private const double scale = 3;
        public LinkLeftIdle(Texture2D sprite)
        {
            linkSprite = sprite;
            frame = new Rectangle(30, 0, 16, 16);
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
