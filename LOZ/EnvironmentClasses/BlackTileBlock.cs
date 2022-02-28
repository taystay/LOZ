
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnvironmentalClasses
{
    public class BlackTileBlock: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public Rectangle GetHitBox() {

            return new Rectangle(itemLocation.X, itemLocation.Y, 32, 32);
        }
 
        public BlackTileBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlackTileSprite();
            this.itemLocation = itemLocation;
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemLocation);
        }

    }
}
