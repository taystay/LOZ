using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Inventory;

namespace LOZ.Hud
{
    class UserCurrentItemHud : HudElement
    {
        private LinkInventory _linkInventory;
        public UserCurrentItemHud(LinkInventory linkInventory)
        {
            _linkInventory = linkInventory;
        }
        public void Update()
        {
            //Might not even need this at all lol
        }

        private void DrawInventorySprites()
        {
             Point BItemLocation = new Point();
             Point AItemLocation = new Point();
             List<LinkItems> items = _linkInventory.linkItemsHeld;
             
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
