using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class StairsBlock: IEnvironment
    {
        private ISprite sprite;
        private Point itemLocation;

        public StairsBlock(Point itemLocation, double scale)
        {
            sprite = BlockSpriteFactory.Instance.CreateStairsBlockSprite(scale);
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
