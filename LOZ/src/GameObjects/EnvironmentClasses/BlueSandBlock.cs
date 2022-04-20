using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class BlueSandBlock: AbstractTileBlock
    {
        public BlueSandBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlueSandBlockSprite();
            this.itemLocation = itemLocation;
        }
        public override Hitbox GetHitBox() =>
            new Hitbox(0, 0, 0, 0);
    }
}
