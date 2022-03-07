using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;
using LOZ.DungeonClasses;

namespace LOZ.EnvironmentalClasses
{
    public class MulticoloredBlock2: AbstractTileBlock
    {
        public MulticoloredBlock2(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateMulticolored2Sprite();
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
