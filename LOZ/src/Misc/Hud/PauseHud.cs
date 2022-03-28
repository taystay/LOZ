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

namespace LOZ.Hud
{
    public class PauseHud : HudElement
    {
        private LinkInventory _linkInventory;
        private SpriteFont font;
        private ISprite Hud;
        private Point drawLocation = new Point(0, 0);
        private HudElement secondaryHud;
        public PauseHud(LinkInventory linkInventory, ContentManager content)
        {
            _linkInventory = linkInventory;
            font = content.Load<SpriteFont>("File"); // Use the name of your sprite font file here instead of 'Score'.
            Hud = Factories.DisplaySpriteFactory.Instance.CreatePauseSprite();
            secondaryHud = new UserCurrentItemHud(linkInventory, content, new Point(0,600));
        }
        public void Update()
        {
            //Might not even need this at all lol
        }

        private void DrawLinkItems(SpriteBatch spriteBatch)
        {
            List<IGameObjects> items = _linkInventory.useItems;
            int offset = 50;
            int i = 0;
            if (_linkInventory.getItemCounts().bombs > 0)
            {
                ItemFactory.Instance.CreateBombSprite().Draw(spriteBatch, new Point(525 + offset * i, 200));
                i++;
            }
            foreach (IGameObjects item in items)
            {
                if(TypeC.Check(item, typeof(Compass)))
                {
                    ItemFactory.Instance.CreateClockSprite().Draw(spriteBatch, new Point(525 + offset * i, 200));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hud.Draw(spriteBatch, drawLocation);
            secondaryHud.Draw(spriteBatch);
            DrawLinkItems(spriteBatch);
        }
    }
}
