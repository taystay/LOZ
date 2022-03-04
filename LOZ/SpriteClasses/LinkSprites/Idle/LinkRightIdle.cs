using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkRightIdle : ISprite
    {
        private Texture2D linkSprite;
        private Rectangle frame;
        private const double scale = 3;
        public LinkRightIdle(Texture2D sprite)
        {
            linkSprite = sprite;
            frame = new Rectangle(90, 0, 16, 16);
        }

        public void Update(GameTime timer)
        {
        }
        public void Draw(SpriteBatch spriteBatch, Point location)
        {
            int width = (int)(scale * (int)frame.Width);
            int height = (int)(scale * (int)frame.Height);
            Rectangle destinationRectangle = new Rectangle(location.X - width / 2, location.Y - height / 2, width, height);

            //for SpriteBatch.Begin(...)
            //the paramater idea was from:
            //https://stackoverflow.com/questions/34626732/seeing-wrap-texture-when-using-clamp-mode-in-monogame-pictures-incl
            //https://csharp.hotexamples.com/examples/Microsoft.Xna.Framework.Graphics/SpriteBatch/Begin/php-spritebatch-begin-method-examples.html
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            if (CurrentRoom.Instance.Room.Damaged)
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.HotPink);
            else
                spriteBatch.Draw(linkSprite, destinationRectangle, frame, Color.White);

            spriteBatch.End();
        }
    }
}
