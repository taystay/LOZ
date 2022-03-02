
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class BlackTileBlock: AbstractTileBlock
    {
        public BlackTileBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlackTileSprite();
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
