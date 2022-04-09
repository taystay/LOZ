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
    public class  SelectedItemSlot : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);

        private LinkInventory _inventory;

        public SelectedItemSlot(LinkInventory inventory, Point drawLocation)
        {
            _inventory = inventory;
            DrawPoint = drawLocation;
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
            int SelectedItemIdx = _inventory.currentItem;
            if (SelectedItemIdx < 0 || SelectedItemIdx >= _inventory.inventory.Count) return;

            IItem item = (IItem)_inventory.inventory[SelectedItemIdx];
            item.SetPosition(DrawPoint + _offset);
            item.Draw(spriteBatch);
            
        }
    }
}
