using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using LOZ.DungeonClasses;
using LOZ.ItemsClasses;
using LOZ.GameStateReference;
using LOZ.Room;

namespace LOZ.Hud
{
    public class  BigMap : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);

        private static ISprite room;
        private static ISprite horizontalWalkWay;
        private static ISprite verticalWalkWay;

        private LinkInventory _inventory;

        private Dictionary<Rectangle, Point3D> roomHitBoxes;

        public BigMap(LinkInventory inventory, Point drawLocation)
        {
            _inventory = inventory;
            DrawPoint = drawLocation;
            room = DisplaySpriteFactory.Instance.CreateRoomOnMapSprite();
            verticalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);
            horizontalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);

            roomHitBoxes = new Dictionary<Rectangle, Point3D>();

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
            if (Mouse.GetState().LeftButton != ButtonState.Pressed) return;
            Point mouseLocation = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            foreach(KeyValuePair<Rectangle, Point3D> pair in roomHitBoxes)
            {
                if(pair.Key.Contains(mouseLocation))
                {
                    RoomReference.SetRoomLocationPoint(pair.Value);
                    RoomReference.GetLink().Position = Info.Inside.Center;
                   return;
                }
            }          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_inventory.HasItem(typeof(Map)) && !RoomReference.GetDebug()) return;
            Point3D linkCoor = CurrentRoom.currentLocation;
            ISprite map = ItemFactory.Instance.CreateMapSprite();
            map.ChangeScale(2);
            map.Draw(spriteBatch, new Point(DrawPoint.X - 250 + _offset.X, DrawPoint.Y + 70 + _offset.Y));
            int offsetX = 50;
            int offsetY = 30;
            int startX = DrawPoint.X + _offset.X;
            int startY = DrawPoint.Y + _offset.Y;
            List<Point3D> coords = RoomReference.GetRooms();
            roomHitBoxes = new Dictionary<Rectangle, Point3D>();
            foreach (Point3D point in coords)
            {
                int x = startX + offsetX * point.X;
                int y = startY + offsetY * point.Y;
                room.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y), Color.Black);

                Rectangle b = new Rectangle(startX + offsetX * point.X - 20, startY + offsetY * point.Y - 10, 40, 20);
                if (!roomHitBoxes.ContainsKey(b))
                    roomHitBoxes.Add(b, point);


                ExteriorObject roomObj = RoomReference.GetAllRooms()[point].GetExtObj();
                if (roomObj == null) continue;
                if (roomObj.CanGoUp()) verticalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y - 10), Color.Black); ;
                if (roomObj.CanGoDown()) verticalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y + 10), Color.Black);
                if (roomObj.CanGoLeft()) horizontalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X - 20, startY + offsetY * point.Y), Color.Black);
                if (roomObj.CanGoRight()) horizontalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X + 20, startY + offsetY * point.Y), Color.Black);
            }



            if (_inventory.HasItem(typeof(Compass)))
                room.Draw(spriteBatch, new Point(startX + offsetX * 6, startY + offsetY * 2), Color.Yellow);
            room.Draw(spriteBatch, new Point(startX + offsetX * linkCoor.X, startY + offsetY * linkCoor.Y), Color.Green);
        }
    }
}
