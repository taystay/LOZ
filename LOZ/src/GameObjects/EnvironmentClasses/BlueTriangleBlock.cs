using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.DungeonClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class BlueTriangleBlock: AbstractTileBlock
    {
        public BlueTriangleBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlueTriangleBlockSprite();
            this.itemLocation = itemLocation;
        }
        public BlueTriangleBlock(Point itemLocation, bool pushable)
        {
            Pushable = pushable;
            sprite = BlockSpriteFactory.Instance.CreateBlueTriangleBlockSprite();
            this.itemLocation = itemLocation;
        }
        public override Hitbox GetHitBox()
        {
            int w = Info.BlockWidth;
            return new Hitbox(itemLocation.X - w / 2, itemLocation.Y - w / 2, w, w);
        }
    }
}
