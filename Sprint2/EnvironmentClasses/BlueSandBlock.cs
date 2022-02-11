﻿using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class BlueSandBlock: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public BlueSandBlock(Point itemLocation, double scale)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlueSandBlockSprite(scale);
            this.itemLocation = itemLocation;
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemLocation);
        }

    }
}