using LOZ.SpriteClasses;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.EnvironmentalClasses
{
    public class StairsBlock: AbstractTileBlock
    {
        public StairsBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateStairsBlockSprite();
            this.itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
