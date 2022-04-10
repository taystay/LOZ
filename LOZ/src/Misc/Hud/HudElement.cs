using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Hud
{
    public interface HudElement
    {
        public void Update();
        public void Offset(Point offset);

        public void Draw(SpriteBatch spriteBatch);
    }
}
