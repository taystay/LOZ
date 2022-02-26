using LOZ.SpriteClasses;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Factories;

namespace LOZ.EnvironmentalClasses
{
    public class SolidBlueBlock: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public SolidBlueBlock(Point itemLocation)
        {
            sprite = BlockSpriteFactory.Instance.CreateSolidBlueTileSprite();
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
