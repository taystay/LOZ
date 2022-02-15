
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Factories;

namespace Sprint2.EnvironmentalClasses
{
    public class BlackTileBlock: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public BlackTileBlock(Point itemLocation, double scale)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlackTileSprite(scale);
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
