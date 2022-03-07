using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.DungeonClasses
{
    public class DoorObject : IGameObjects
    {
		private protected ISprite sprite;
		private protected Point itemLocation;
        public DoorObject(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateDoorWay(n);
            itemLocation = location;
        }
		public void Update(GameTime timer)
        {

        }
		public Hitbox GetHitBox()
        {
            return new Hitbox(0, 0, 0, 0);
        }
		public void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, itemLocation);
		}
    }
}
