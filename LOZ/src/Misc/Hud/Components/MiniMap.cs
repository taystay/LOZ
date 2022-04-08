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
    public class  MiniMap : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);
        private ISprite room;

        private LinkInventory _inventory;

        public MiniMap(LinkInventory inventory, Point drawLocation)
        {
            _inventory = inventory;
            DrawPoint = drawLocation;
            room = DisplaySpriteFactory.Instance.CreateBlueMapRoomSprite();

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
            Point3D linkCoor = CurrentRoom.Instance.linkCoor;
            GameFont.Instance.Write(spriteBatch, "Room - " + (linkCoor.X + 6 * linkCoor.Y), 100 + _offset.X, 75 + _offset.Y);
            if (_inventory.HasItem(typeof(Map))) return;
            int offsetX = 25;
            int offsetY = 15;
            int startX = 100 + _offset.X;
            int startY = 125 + _offset.Y;
            List<Point3D> coords = CurrentRoom.Instance.roomList;
            foreach (Point3D point in coords)
            {
                room.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y));
            }
            room.Draw(spriteBatch, new Point(startX + offsetX * linkCoor.X, startY + offsetY * linkCoor.Y), Color.Green);

            if (_inventory.HasItem(typeof(Compass))) return;
            room.Draw(spriteBatch, new Point(startX + offsetX * 6, startY + offsetY * 2), Color.Yellow);
        }
    }
}
