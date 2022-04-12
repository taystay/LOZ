using LOZ.Collision;
using LOZ.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.DungeonClasses
{
    internal abstract class DoorTypeAbstract : IGameObjects
    {
        private protected ISprite sprite;
        private protected Point itemLocation;

        public void Update(GameTime timer) { }
        public virtual bool IsActive()
        {
            return true;
        }
        public Hitbox GetHitBox()
        {
            return new Hitbox(0, 0, 0, 0);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, itemLocation);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Point offset)
        {
            sprite.Draw(spriteBatch, itemLocation + offset);
        }
    }
}
