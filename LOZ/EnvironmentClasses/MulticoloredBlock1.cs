
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;
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
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
