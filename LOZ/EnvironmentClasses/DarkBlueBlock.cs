﻿
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnvironmentalClasses
{
    public class DarkBlueBlock: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public DarkBlueBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateDarkBlueSolidBlockSprite();
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