using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.GameState;
using System.Collections.Generic;

namespace LOZ.Hud
{
    public class UserCurrentItemHud : HudElement
    {
        private LinkInventory _linkInventory;
        private SpriteFont font;
        private ISprite room;
        private Point _offset;

        public UserCurrentItemHud(LinkInventory linkInventory, ContentManager content)
        {
            _linkInventory = linkInventory;
            font = content.Load<SpriteFont>("File"); // Use the name of your sprite font file here instead of 'Score'.
            _offset = new Point(0, 0);
            room = DisplaySpriteFactory.Instance.CreateBlueMapRoomSprite();
        }

        public UserCurrentItemHud(LinkInventory linkInventory, ContentManager content, Point offset)
        {
            _linkInventory = linkInventory;
            font = content.Load<SpriteFont>("File"); // Use the name of your sprite font file here instead of 'Score'.
            _offset = offset;
            room = DisplaySpriteFactory.Instance.CreateBlueMapRoomSprite();
        }
        public void Update()
        {
            //Might not even need this at all lol
        }

        private void DrawSelectedItems(SpriteBatch spriteBatch)
        {
            Point ALocation = new Point(590 + _offset.X, 160 + _offset.Y);
            if(_linkInventory.hasSword)
            {
                ISprite sword = ItemFactory.Instance.CreateSwordSprite();
                sword.ChangeScale(1.5);
                sword.Draw(spriteBatch, ALocation);
            }
            Point BLocation = new Point(500 + _offset.X, 160 + _offset.Y);
            ISprite sprite = _linkInventory.GetSelectedItemSprite();
            if (sprite == null) return;
            sprite.Draw(spriteBatch, BLocation);
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            Point3D linkCoor = CurrentRoom.Instance.linkCoor;
            GameFont.Instance.Write(spriteBatch, "Room - " + (linkCoor.X + 6 * linkCoor.Y), 100 + _offset.X, 75 + _offset.Y);
            if (!_linkInventory.hasMap) return;
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

            if (!_linkInventory.hasCompass) return;
            room.Draw(spriteBatch, new Point(startX + offsetX * 6, startY + offsetY * 2), Color.Yellow);

        }

        private void DrawHearts(SpriteBatch spriteBatch)
        {
            Point currentDrawPoint = new Point(725 + _offset.X, 200 + _offset.Y);
            int offset = 40;
            ISprite fullHeart = DisplaySpriteFactory.Instance.GetHudHeart(true);
            ISprite halfHeart = DisplaySpriteFactory.Instance.GetHudHeart(false);
            int linkCurrentHealth = Room.Link.Health;
            if (linkCurrentHealth < 0) return;

            for(int i = 0; i < linkCurrentHealth / 2; i++)
            {
                fullHeart.Draw(spriteBatch, currentDrawPoint);
                currentDrawPoint.X += offset;
            }

            if(linkCurrentHealth % 2 == 1)
            {
                halfHeart.Draw(spriteBatch, currentDrawPoint);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "x" + _linkInventory.getItemCounts().rupees, new Vector2(375 + _offset.X, 100 + _offset.Y), Color.White);
            spriteBatch.DrawString(font, "x" + _linkInventory.getItemCounts().keys, new Vector2(375 + _offset.X, 150 + _offset.Y), Color.White);
            spriteBatch.DrawString(font, "x" + _linkInventory.getItemCounts().bombs, new Vector2(375 + _offset.X, 200 + _offset.Y), Color.White);
            spriteBatch.End();

            ISprite hud = DisplaySpriteFactory.Instance.CreateHUDSprite();
            hud.Draw(spriteBatch, new Point(0 + _offset.X, 0 + _offset.Y));
            DrawHearts(spriteBatch);
            DrawSelectedItems(spriteBatch);
            DrawMap(spriteBatch);
        }
    }
}
