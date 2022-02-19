using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint2.ItemsClasses
{
    abstract class ItemAbstract : IItem
    {
        private protected ISprite sprite;
        private protected Point _itemLocation;
        private protected bool spriteActivity = true;

        public bool SpriteActive()
        {
            return spriteActivity;
        }

        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, _itemLocation);
        }



    }
}
