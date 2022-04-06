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
        private Point drawLocation = new Point(0, 75);
        private HudElement secondaryHud;
        private bool keyPressed = false;

        private Dictionary<Rectangle, Point3D> roomMapLocation;

        public PauseHud(LinkInventory linkInventory, ContentManager content)
        {
            _linkInventory = linkInventory;
            font = content.Load<SpriteFont>("File"); // Use the name of your sprite font file here instead of 'Score'.
            Hud = DisplaySpriteFactory.Instance.CreatePauseSprite();
       
            secondaryHud = new UserCurrentItemHud(linkInventory, content, new Point(0,600));
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

        public void Draw(SpriteBatch spriteBatch)
        {
            Hud.Draw(spriteBatch, drawLocation);
            secondaryHud.Draw(spriteBatch);
            PauseHUDHelper.DrawLinkItems(spriteBatch,_linkInventory);
            PauseHUDHelper.DrawMap(spriteBatch, _linkInventory, roomMapLocation);
            PauseHUDHelper.DrawCompass(spriteBatch, _linkInventory);
        }
    }
}
