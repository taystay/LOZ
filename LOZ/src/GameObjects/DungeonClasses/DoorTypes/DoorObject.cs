using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.DungeonClasses
{
    internal class DoorObject : DoorTypeAbstract
    {
		private protected Point position;
        public DoorObject(Point location, DoorLocation n)
        {
            sprite = Factories.DungeonFactory.Instance.CreateDoorWay(n);
            position = location;
        }

		public override void Draw(SpriteBatch spriteBatch) {
			sprite.Draw(spriteBatch, position);
		}
    }
}
