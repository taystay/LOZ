using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.GameState;
using System.Collections.Generic;
using LOZ.DungeonClasses;
using LOZ.Inventory;

namespace LOZ.Hud
{
    internal static class PauseHUDHelper
    {
        private static ISprite horizontalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);
        private static ISprite verticalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);
        private static ISprite room = DisplaySpriteFactory.Instance.CreateRoomOnMapSprite();
        private static ISprite selectSprite = DisplaySpriteFactory.Instance.CreateSelectItemSprite();

        #region itemDrawing
        private static int startx = 525;
        private static int starty = 200;
        private static int offset = 75;
        private static int i = 0;
        #endregion

        internal static void DrawMap(SpriteBatch spriteBatch, LinkInventory _linkInventory, Dictionary<Rectangle, Point3D> roomMapLocation)
        {
            if (!_linkInventory.hasMap && !Room.DebugMode) return;
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
                Rectangle hitbox = new Rectangle(x - 20, y - 10, 40, 20);
                if (!roomMapLocation.ContainsKey(hitbox))
                    roomMapLocation.Add(hitbox, point);
                ExteriorObject roomObj = CurrentRoom.Instance.Rooms[point].exterior;
                if (roomObj == null) continue;
                if (roomObj.CanGoUp()) verticalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y - 10), Color.Black); ;
                if (roomObj.CanGoDown()) verticalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y + 10), Color.Black);
                if (roomObj.CanGoLeft()) horizontalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X - 20, startY + offsetY * point.Y), Color.Black);
                if (roomObj.CanGoRight()) horizontalWalkWay.Draw(spriteBatch, new Point(startX + offsetX * point.X + 20, startY + offsetY * point.Y), Color.Black);
            }



            if (_linkInventory.hasCompass)
                room.Draw(spriteBatch, new Point(startX + offsetX * 6, startY + offsetY * 2), Color.Yellow);
            room.Draw(spriteBatch, new Point(startX + offsetX * linkCoor.X, startY + offsetY * linkCoor.Y), Color.Green);
        }

        internal static void DrawCompass(SpriteBatch spriteBatch, LinkInventory _linkInventory)
        {
            if (!_linkInventory.hasCompass) return;
            ISprite compass = ItemFactory.Instance.CreateCompassSprite();
            compass.ChangeScale(2);
            compass.Draw(spriteBatch, new Point(190, 620));
        }

        internal static void DrawLinkItems(SpriteBatch spriteBatch, LinkInventory _linkInventory)
        {
            if (_linkInventory.hasBomb)
                DrawSingleItem(_linkInventory.bombId, spriteBatch, _linkInventory);
            if (_linkInventory.hasBow)
                DrawSingleItem(_linkInventory.bowId, spriteBatch, _linkInventory);
            if (_linkInventory.hasPortalGun)
                DrawSingleItem(_linkInventory.gunId, spriteBatch, _linkInventory);

            i = 0;
        }


        private static void DrawSingleItem(int id, SpriteBatch spriteBatch, LinkInventory _linkInventory)
        {
            ISprite sprite = _linkInventory.GetSpriteById(id);
            if (_linkInventory.selectedItem == id)
            {
                selectSprite.Draw(spriteBatch, new Point(startx + i * offset, starty));
                sprite.Draw(spriteBatch, new Point(275, 200));
            }
            sprite.Draw(spriteBatch, new Point(startx + i * offset, starty));
            i++;
        }
    }
}
