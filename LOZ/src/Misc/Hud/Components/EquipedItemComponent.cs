using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;
using LOZ.ItemsClasses;

namespace LOZ.Hud
{
    public class EquipedItemComponent : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);

        private LinkInventory _inventory;
        
        public EquipedItemComponent(LinkInventory inventory, Point drawLocation)
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
            Point ALocation = new Point( DrawPoint.X + 90 + _offset.X, DrawPoint.Y + _offset.Y + 90);
            Point BLocation = new Point(DrawPoint.X + _offset.X, DrawPoint.Y +  _offset.Y + 90);
            bool hasSword = false;
            foreach(IGameObjects item in _inventory.inventory)
            {
                if (TypeC.Check(item, typeof(Sword)))
                    hasSword = true;
            }
            if (hasSword)
            {
                ISprite sword = ItemFactory.Instance.CreateSwordSprite();
                sword.ChangeScale(1.5);
                sword.Draw(spriteBatch, ALocation);
            }

            int BSlotItemIdx = _inventory.currentItem;
            if (BSlotItemIdx < 0 || BSlotItemIdx > _inventory.inventory.Count - 1) return;
                
            if (_inventory.inventory[BSlotItemIdx] == null) return;

            IGameObjects o = _inventory.inventory[BSlotItemIdx];
            IItem gameItem = (IItem)o;
            gameItem.SetPosition(BLocation);
            gameItem.Draw(spriteBatch);
        }
    }
}
