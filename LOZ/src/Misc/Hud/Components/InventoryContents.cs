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
    public class InventoryContents : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);


        private LinkInventory _inventory;

        public InventoryContents(LinkInventory inventory, Point drawLocation)
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
            int startx = 525 + _offset.X;
            int starty = 200 + _offset.Y;
            int offset = 75;
            int i = 0;
            List<System.Type> typesDrawn = new List<System.Type>();
            foreach(IGameObjects o in _inventory.inventory)
            {
                IItem item = (IItem)o;
                if (typesDrawn.Contains(item.GetType()) || !item.InventoryItem) continue;
                item.SetPosition(new Point(startx + offset * i, starty));
                item.Draw(spriteBatch);
                i++;
                typesDrawn.Add(item.GetType());
            }
        }
    }
}
