using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class SolidBlueBlock: AbstractTileBlock
    {
        public SolidBlueBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateSolidBlueTileSprite();
            this.itemLocation = itemLocation;
        }
        public override Hitbox GetHitBox() => new Hitbox(0, 0, 0, 0);
    }
}
