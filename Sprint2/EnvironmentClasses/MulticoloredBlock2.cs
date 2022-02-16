
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.EnvironmentalClasses
{
    public class MulticoloredBlock2: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public MulticoloredBlock2(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateMulticolored2Sprite();
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
