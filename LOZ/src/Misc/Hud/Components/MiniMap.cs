using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Room;
using LOZ.GameStateReference;
using System.Collections.Generic;
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
            Point3D linkCoor = RoomReference.GetCurrLocation();
            GameFont.Instance.Write(spriteBatch, "Room - " + linkCoor.X + " " + linkCoor.Y, DrawPoint.X + _offset.X, DrawPoint.Y - 50 + _offset.Y);
            if (!_inventory.HasItem(typeof(Map))) return;
            int offsetX = 25;
            int offsetY = 15;
            int startX = DrawPoint.X + _offset.X;
            int startY = DrawPoint.Y + _offset.Y;
            List<Point3D> coords = RoomReference.GetRooms();
            foreach (Point3D point in coords)
            {
                if (point.Z != linkCoor.Z) return;
                room.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y));
            }
            room.Draw(spriteBatch, new Point(startX + offsetX * linkCoor.X, startY + offsetY * linkCoor.Y), Color.Green);

            if (!_inventory.HasItem(typeof(Compass))) return;
            room.Draw(spriteBatch, new Point(startX + offsetX * 6, startY + offsetY * 2), Color.Yellow);
        }
    }
}
