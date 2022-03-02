
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class MulticoloredBlock1: AbstractTileBlock
    {

        public MulticoloredBlock1(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateMulticolored1Sprite();
            this.itemLocation = itemLocation;
        }
        public override Hitbox GetHitBox()
        {
            return new Hitbox(itemLocation.X - 32, itemLocation.Y - 32, 48, 48);
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
