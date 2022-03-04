﻿
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class InvisibleBlock: AbstractTileBlock
    {
        private int width;
        private int height;
        public InvisibleBlock(Point itemLocation, int width, int height)
        {
            this.itemLocation = itemLocation;
            this.width = width;
            this.height = height;
        }
        public override Hitbox GetHitBox()
        {
            return new Hitbox(itemLocation.X, itemLocation.Y, width, height);
        }
        public override void Update(GameTime gameTime)
        { 

        }

        public override void Draw(SpriteBatch sprite)
        {

        }

    }
}