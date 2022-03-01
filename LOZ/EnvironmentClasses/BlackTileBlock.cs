
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnvironmentalClasses
{
    public class BlackTileBlock: AbstractTileBlock
    {
        public BlackTileBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlackTileSprite();
            this.itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
