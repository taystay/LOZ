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

namespace LOZ.Hud
{
    public class InventoryHud : HudElement
    {
        private List<HudComponent> componenets;
        private LinkInventory _linkInventory;

        private ISprite ui = DisplaySpriteFactory.Instance.CreatePauseSprite();
        public InventoryHud(LinkInventory linkInventory)
        {
            _linkInventory = linkInventory;
            componenets = new List<HudComponent>();
            componenets.Add(new HeartComponent(new Point(700,800)));
            componenets.Add(new EquipedItemComponent(linkInventory, new Point(500, 660)));
            componenets.Add(new MiniMap(linkInventory, new Point(100, 725)));
            componenets.Add(new NumberedItems(linkInventory, new Point(0, 600)));
            componenets.Add(new BigMap(linkInventory, new Point(300, 600)));
            componenets.Add(new InventoryContents(linkInventory, new Point(500, 200)));
        }

        public void Update()
        {
            foreach (HudComponent component in componenets)
            {
                component.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ui.Draw(spriteBatch, new Point(0, 50));
            foreach(HudComponent component in componenets)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
