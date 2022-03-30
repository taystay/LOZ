using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.GameState;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Hud
{
    public class PauseHud : HudElement
    {
        private LinkInventory _linkInventory;
        private SpriteFont font;
        private ISprite Hud;
        private ISprite selectSprite;
        private ISprite room;
        private ISprite linkLocation;
        private ISprite triforceLoc;
        private Point drawLocation = new Point(0, 0);
        private HudElement secondaryHud;
        private bool keyPressed = false;

        #region itemDrawing
        private int startx = 525;
        private int starty = 200;
        private int offset = 75;
        private int i = 0;
        #endregion
        public PauseHud(LinkInventory linkInventory, ContentManager content)
        {
            _linkInventory = linkInventory;
            font = content.Load<SpriteFont>("File"); // Use the name of your sprite font file here instead of 'Score'.
            Hud = DisplaySpriteFactory.Instance.CreatePauseSprite();
            selectSprite = DisplaySpriteFactory.Instance.CreateSelectItemSprite();
            secondaryHud = new UserCurrentItemHud(linkInventory, content, new Point(0,600));
            room = DisplaySpriteFactory.Instance.CreateRoomOnMapSprite();
            linkLocation = DisplaySpriteFactory.Instance.CreateLinkIndicator();
            triforceLoc = DisplaySpriteFactory.Instance.CreateTriforceIndicator();
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !keyPressed)
            {
                _linkInventory.selectedItem++;
                keyPressed = true;
            } else if (!Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                keyPressed = false;
            }
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            if (!_linkInventory.hasMap) return;
            ISprite map = ItemFactory.Instance.CreateMapSprite();
            map.ChangeScale(2);
            map.Draw(spriteBatch, new Point(190, 455));
            int offset = 38;
            int startX = 450;
            int startY = 350;
            List<Point3D> coords = CurrentRoom.Instance.roomList;
            foreach(Point3D point in coords)
            {
                room.Draw(spriteBatch, new Point(startX + offset * point.X, startY + offset * point.Y));
            }
            Point3D linkCoor = CurrentRoom.Instance.linkCoor;
            linkLocation.Draw(spriteBatch, new Point(startX + offset * linkCoor.X, startY + offset * linkCoor.Y));

            if (!_linkInventory.hasCompass) return;
            triforceLoc.Draw(spriteBatch, new Point(startX + offset * 6, startY + offset * 2));
        }

        private void DrawCompass(SpriteBatch spriteBatch)
        {
            if (!_linkInventory.hasCompass) return;
            ISprite compass = ItemFactory.Instance.CreateCompassSprite();
            compass.ChangeScale(2);
            compass.Draw(spriteBatch, new Point(190, 620));
        }

        private void DrawSingleItem(int id, SpriteBatch spriteBatch)
        {
            ISprite sprite = _linkInventory.GetSpriteById(id);
            if(_linkInventory.selectedItem == id)
            {
                selectSprite.Draw(spriteBatch, new Point(startx + i * offset, starty));
                sprite.Draw(spriteBatch, new Point(275, 200));
            }    
            sprite.Draw(spriteBatch, new Point(startx + i * offset, starty));
            i++;
        }

        private void DrawLinkItems(SpriteBatch spriteBatch)
        {
            if (_linkInventory.hasBomb)
                DrawSingleItem(_linkInventory.bombId, spriteBatch);      
            if (_linkInventory.hasBow)
                DrawSingleItem(_linkInventory.bowId, spriteBatch);
            i = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hud.Draw(spriteBatch, drawLocation);
            secondaryHud.Draw(spriteBatch);
            DrawLinkItems(spriteBatch);
            DrawMap(spriteBatch);
            DrawCompass(spriteBatch);
        }
    }
}
