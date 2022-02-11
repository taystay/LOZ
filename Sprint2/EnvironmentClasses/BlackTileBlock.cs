using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
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
