using Microsoft.Xna.Framework;
using LOZ.Factories;
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
        public override Hitbox GetHitBox() =>
            new Hitbox(0, 0, 0, 0);
    }
}
