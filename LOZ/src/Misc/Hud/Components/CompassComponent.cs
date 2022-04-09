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
    public class  CompassComponent : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);

        private static ISprite compass;
        private static ISprite horizontalWalkWay;
        private static ISprite verticalWalkWay;

        private LinkInventory _inventory;

        public CompassComponent(LinkInventory inventory, Point drawLocation)
        {
            _inventory = inventory;
            DrawPoint = drawLocation;
            compass = ItemFactory.Instance.CreateCompassSprite();
            compass.ChangeScale(2);

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
            if (_inventory.HasItem(typeof(Compass))) return;
            compass.Draw(spriteBatch, DrawPoint + _offset);
        }
    }
}
