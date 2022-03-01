
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnvironmentalClasses
{
    public class BlueSandBlock: AbstractTileBlock
    {
  

        public BlueSandBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlueSandBlockSprite();
            this.itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
