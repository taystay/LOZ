using LOZ.SpriteClasses;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.EnvironmentalClasses
{
    public class StairsBlock: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public StairsBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateStairsBlockSprite();
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
