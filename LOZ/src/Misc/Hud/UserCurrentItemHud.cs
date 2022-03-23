using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using LOZ.Inventory;
using LOZ.Factories;
using LOZ.SpriteClasses;

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

        private void DrawInventorySprites()
        {

             
        }

        public void Draw(SpriteBatch spriteBatch)
        {

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
