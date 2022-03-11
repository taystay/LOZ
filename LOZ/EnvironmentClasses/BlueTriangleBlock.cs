
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.DungeonClasses;
using LOZ.SpriteClasses;
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
            if(! Pushable)
                return new Hitbox(itemLocation.X - w / 2, itemLocation.Y - w / 2, w, w);
            else
                return new Hitbox(itemLocation.X - w / 2, itemLocation.Y - w / 2, w - 5, w - 5);
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
