
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnvironmentalClasses
{
    public class DarkBlueBlock: AbstractTileBlock
    {
        public DarkBlueBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateDarkBlueSolidBlockSprite();
            this.itemLocation = itemLocation;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
