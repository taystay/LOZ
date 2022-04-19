using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.Hud
{
    public class  NumberedItems : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);
        private ISprite hud;

        private LinkInventory _inventory;
        public NumberedItems(LinkInventory inventory, Point drawLocation)
        {
            _inventory = inventory;
            DrawPoint = drawLocation;
            hud = DisplaySpriteFactory.Instance.CreateHUDSprite();
            
        }
        public void OffsetHud(Point offset)
        {
            _offset.X += offset.X;
            _offset.Y += offset.Y;
        }
        public void ResetHud() => _offset = new Point();
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch)
        {
            GameFont.Instance.Write(spriteBatch, "x" + _inventory.rupeeCount, DrawPoint.X + 375 + _offset.X, DrawPoint.Y + 100 + _offset.Y);
            GameFont.Instance.Write(spriteBatch, "x" + _inventory.keyCount, DrawPoint.X + 375 + _offset.X, DrawPoint.Y + 150 + _offset.Y);
            GameFont.Instance.Write(spriteBatch, "x" + _inventory.bombCount, DrawPoint.X + 375 + _offset.X, DrawPoint.Y + 200 + _offset.Y);
            hud.Draw(spriteBatch, new Point(DrawPoint.X + _offset.X, DrawPoint.Y + _offset.Y));
        }
    }
}
