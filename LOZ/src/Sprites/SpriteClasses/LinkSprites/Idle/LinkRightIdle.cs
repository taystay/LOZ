using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkRightIdle : AbstractLinkSprite
    {
        public LinkRightIdle(Texture2D sprite)
        {
            linkSprite = sprite;
            frame = new Rectangle(90, 0, 16, 16);
        }

        public override void Update(GameTime timer)
        {
        }
    }
}
