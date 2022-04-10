using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using System.Collections.Generic;

namespace LOZ.Hud
{
    public class InventoryHud : HudElement
    {
        private List<HudComponent> componenets;
        private LinkInventory _linkInventory;
        private Point _offset;
        private ISprite ui = DisplaySpriteFactory.Instance.CreatePauseSprite();
        public InventoryHud(LinkInventory linkInventory)
        {
            _offset = new Point(0, 0);
            _linkInventory = linkInventory;
            componenets = new List<HudComponent>();
            componenets.Add(new HeartComponent(new Point(700,800)));
            componenets.Add(new EquipedItemComponent(linkInventory, new Point(500, 660)));
            componenets.Add(new MiniMap(linkInventory, new Point(100, 725)));
            componenets.Add(new NumberedItems(linkInventory, new Point(0, 600)));
            componenets.Add(new BigMap(linkInventory, new Point(440, 370)));
            componenets.Add(new InventoryContents(linkInventory, new Point(500, 200)));
            componenets.Add(new SelectedItemSlot(linkInventory, new Point(275, 175)));
            componenets.Add(new CompassComponent(linkInventory, new Point(185, 600)));
        }

        public void Offset(Point offset)
        {
            _offset.X += offset.X;
            _offset.Y += offset.Y;
            foreach(HudComponent component in componenets)
            {
                component.OffsetHud(offset);
            }
        }

        public void Update()
        {       
            foreach (HudComponent component in componenets)
            {
                component.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ui.Draw(spriteBatch, new Point(0 + _offset.X, 50 + _offset.Y));
            foreach(HudComponent component in componenets)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
