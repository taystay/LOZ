using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnvironmentalClasses
{
    public class MulticoloredBlock2: AbstractTileBlock
    {
        public MulticoloredBlock2(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateMulticolored2Sprite();
            this.itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
