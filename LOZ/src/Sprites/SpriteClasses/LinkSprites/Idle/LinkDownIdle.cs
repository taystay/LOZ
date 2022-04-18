using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.GameState;

namespace LOZ.SpriteClasses.LinkSprites
{
    class LinkDownIdle : AbstractLinkSprite
    {
        public LinkDownIdle(Texture2D sprite)
        {
            linkSprite = sprite;
            frame = new Rectangle(0, 0, 16, 16);
        }
        public override void Update(GameTime timer) { }
    }
}
