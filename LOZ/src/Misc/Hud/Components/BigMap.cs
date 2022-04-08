﻿using Microsoft.Xna.Framework.Graphics;
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
    public class  BigMap : HudComponent
    {
        public Point DrawPoint { get; set; }
        private Point _offset = new Point(0, 0);

        private static ISprite room;
        private static ISprite horizontalWalkWay;
        private static ISprite verticalWalkWay;

        private LinkInventory _inventory;

        public BigMap(LinkInventory inventory, Point drawLocation)
        {
            _inventory = inventory;
            DrawPoint = drawLocation;
            room = DisplaySpriteFactory.Instance.CreateRoomOnMapSprite();
            verticalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);
            horizontalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);


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
            if (_inventory.HasItem(typeof(Map)) && !Room.DebugMode) return;
            Point3D linkCoor = CurrentRoom.Instance.linkCoor;
            ISprite map = ItemFactory.Instance.CreateMapSprite();
            map.ChangeScale(2);
            map.Draw(spriteBatch, new Point(190, 455));
            int offsetX = 50;
            int offsetY = 30;
            int startX = 450;
            int startY = 350;
            List<Point3D> coords = CurrentRoom.Instance.roomList;
            foreach (Point3D point in coords)
            {
                int x = startX + offsetX * point.X;
                int y = startY + offsetY * point.Y;
                room.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y), Color.Black);
                ExteriorObject roomObj = CurrentRoom.Instance.Rooms[point].exterior;
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
