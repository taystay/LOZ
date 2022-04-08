using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.GameState;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using LOZ.DungeonClasses;
using LOZ.Collision;
using LOZ.ItemsClasses;

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

        public void ResetHud()
        {
            _offset = new Point();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GameFont.Instance.Write(spriteBatch, "x" + _inventory.rupeeCount, DrawPoint.X + 375, DrawPoint.Y + 100);
            GameFont.Instance.Write(spriteBatch, "x" + _inventory.keyCount, DrawPoint.X + 375, DrawPoint.Y + 150);
            GameFont.Instance.Write(spriteBatch, "x" + _inventory.bombCount, DrawPoint.X + 375, DrawPoint.Y + 200);
            hud.Draw(spriteBatch, DrawPoint);
        }
    }
}
