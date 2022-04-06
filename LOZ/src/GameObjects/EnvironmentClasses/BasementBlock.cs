using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class BasementBlock: AbstractTileBlock
    {
        public BasementBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBasementBlockSprite();
            this.itemLocation = itemLocation;
        }
        public override Hitbox GetHitBox()
        {
            return new Hitbox(itemLocation.X - 24, itemLocation.Y - 24, 48, 48);
        }
   

    }
}
