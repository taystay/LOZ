using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Hud
{
    public interface HudComponent
    {
        public Point DrawPoint { get; set; }
        public void OffsetHud(Point offset);
        public void ResetHud();
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
