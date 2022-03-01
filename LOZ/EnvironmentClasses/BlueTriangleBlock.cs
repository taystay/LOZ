
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnvironmentalClasses
{
    public class BlueTriangleBlock: AbstractTileBlock
    {

        public BlueTriangleBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlueTriangleBlockSprite();
            this.itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
