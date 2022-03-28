using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkLeftIdle : AbstractLinkSprite
    {
        public LinkLeftIdle(Texture2D sprite)
        {
            linkSprite = sprite;
            frame = new Rectangle(30, 0, 16, 16);
        }
        public override void Update(GameTime timer)
        {
        }
    }
}
