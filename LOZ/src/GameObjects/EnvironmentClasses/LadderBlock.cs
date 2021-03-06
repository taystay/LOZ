using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.EnvironmentalClasses
{
    public class LadderBlock: AbstractTileBlock
    {
        public LadderBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateLadderSprite();
            this.itemLocation = itemLocation;
        }
        public override Hitbox GetHitBox()
        {
            int w = Info.BlockWidth;
            return new Hitbox(itemLocation.X - w / 2, itemLocation.Y - w / 2, 0, 0);
        }
    }
}
