using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.EnvironmentalClasses
{
    public class MulticoloredBlock1: AbstractTileBlock
    {

        public MulticoloredBlock1(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateMulticolored1Sprite();
            this.itemLocation = itemLocation;
        }
        public override Hitbox GetHitBox()
        {
            int w = Info.BlockWidth;
            return new Hitbox(itemLocation.X - w / 2, itemLocation.Y - w / 2, w, w);
        }
    }
}
