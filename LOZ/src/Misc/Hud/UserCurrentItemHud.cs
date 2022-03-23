using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.GameState;

namespace LOZ.Hud
{
    public class UserCurrentItemHud : HudElement
    {
        private LinkInventory _linkInventory;
        private SpriteFont font;
        public UserCurrentItemHud(LinkInventory linkInventory, ContentManager content)
        {
            _linkInventory = linkInventory;
            font = content.Load<SpriteFont>("File"); // Use the name of your sprite font file here instead of 'Score'.
        }
        public void Update()
        {
            //Might not even need this at all lol
        }

        private void DrawHearts(SpriteBatch spriteBatch)
        {
            Point currentDrawPoint = new Point(725, 200);
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
            DrawHearts(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "x" + _linkInventory.getItemCounts().rupees, new Vector2(375, 100), Color.White);
            spriteBatch.DrawString(font, "x" + _linkInventory.getItemCounts().keys, new Vector2(375, 150), Color.White);
            spriteBatch.DrawString(font, "x" + _linkInventory.getItemCounts().bombs, new Vector2(375, 200), Color.White);
            spriteBatch.End();

            ISprite hud = DisplaySpriteFactory.Instance.CreateHUDSprite();
            hud.Draw(spriteBatch, new Point(0, 0));
        }
    }
}
