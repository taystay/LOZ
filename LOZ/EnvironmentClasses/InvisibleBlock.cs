
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class InvisibleBlock: AbstractTileBlock
    {

        public InvisibleBlock(Point itemLocation)
        {
            this.itemLocation = itemLocation; 
        }
        public override Hitbox GetHitBox()
        {
            return new Hitbox(itemLocation.X - 24, itemLocation.Y - 24, 48, 48);
        }
        public override void Update(GameTime gameTime)
        { 

        }

        public override void Draw(SpriteBatch sprite)
        {

        }

    }
}
