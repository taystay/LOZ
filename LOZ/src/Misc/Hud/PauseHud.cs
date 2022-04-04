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

namespace LOZ.Hud
{
    public class PauseHud : HudElement
    {
        private LinkInventory _linkInventory;
        private SpriteFont font;
        private ISprite Hud;
        private ISprite selectSprite;
        private ISprite room;
        private ISprite horizontalWalkWay;
        private ISprite verticalWalkWay;
        private Point drawLocation = new Point(0, 75);
        private HudElement secondaryHud;
        private bool keyPressed = false;

        private Dictionary<Rectangle, Point3D> roomMapLocation;

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
            horizontalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);
            verticalWalkWay = DisplaySpriteFactory.Instance.GetMapWalk(10, 10);
            roomMapLocation = new Dictionary<Rectangle, Point3D>();
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
            if (Mouse.GetState().LeftButton != ButtonState.Pressed) return;
            Point mouseloc = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            foreach(KeyValuePair<Rectangle, Point3D> p in roomMapLocation)
            {
                if (!p.Key.Contains(mouseloc)) continue;
                CurrentRoom.Instance.linkCoor = p.Value;
                Room.Link.ChangePosition(new Point(Info.Inside.X + Info.Inside.Width / 2, Info.Inside.Y + Info.Inside.Height / 2));
            }
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            if (!_linkInventory.hasMap) return;
            Point3D linkCoor = CurrentRoom.Instance.linkCoor;
            ISprite map = ItemFactory.Instance.CreateMapSprite();
            map.ChangeScale(2);
            map.Draw(spriteBatch, new Point(190, 455));
            int offsetX = 50;
            int offsetY = 30;
            int startX = 450;
            int startY = 350;
            List<Point3D> coords = CurrentRoom.Instance.roomList;
            foreach(Point3D point in coords)
            {
                int x = startX + offsetX * point.X;
                int y = startY + offsetY * point.Y;
                room.Draw(spriteBatch, new Point(startX + offsetX * point.X, startY + offsetY * point.Y), Color.Black);
                Rectangle hitbox = new Rectangle(x - 20, y - 10, 40, 20);
                if(!roomMapLocation.ContainsKey(hitbox))
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
