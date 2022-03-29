using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.GameState;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework.Input;
using LOZ.CommandClasses;

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
            Hud = Factories.DisplaySpriteFactory.Instance.CreatePauseSprite();
            selectSprite = Factories.DisplaySpriteFactory.Instance.CreateSelectItemSprite();
            secondaryHud = new UserCurrentItemHud(linkInventory, content, new Point(0,600));
            room = Factories.DisplaySpriteFactory.Instance.CreateRoomOnMapSprite();
            linkLocation = DisplaySpriteFactory.Instance.CreateLinkIndicator();
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
            if (_linkInventory.selectedItem != _linkInventory.mapId) return;
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
        }

        private void DrawSingleItem(int id, SpriteBatch spriteBatch)
        {
            ISprite sprite = _linkInventory.GetSpriteById(id);
            if(_linkInventory.selectedItem == id)
                selectSprite.Draw(spriteBatch, new Point(startx + i * offset, starty));
            sprite.Draw(spriteBatch, new Point(startx + i * offset, starty));
            i++;
        }

        private void DrawLinkItems(SpriteBatch spriteBatch)
        {
            if (_linkInventory.hasMap)
                DrawSingleItem(_linkInventory.mapId, spriteBatch);
            if (_linkInventory.hasCompass)
                DrawSingleItem(_linkInventory.compassId, spriteBatch);
            if (_linkInventory.hasBomb)
                DrawSingleItem(_linkInventory.bombId, spriteBatch);      
            if (_linkInventory.hasBow)
                DrawSingleItem(_linkInventory.bowId, spriteBatch);
            if (_linkInventory.hasClock)
                DrawSingleItem(_linkInventory.clockId, spriteBatch);

            i = 0;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hud.Draw(spriteBatch, drawLocation);
            secondaryHud.Draw(spriteBatch);
            DrawLinkItems(spriteBatch);
            DrawMap(spriteBatch);
        }
    }
}
