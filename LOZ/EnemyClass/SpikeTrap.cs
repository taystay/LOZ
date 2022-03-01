using LOZ.SpriteClasses;
using LOZ.Factories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.EnemyClass
{
    class SpikeTrap : AbstractEnemy
    {
        public SpikeTrap(Point location) {
            _texture= EnemySpriteFactory.Instance.CreateTrap();
            Position = location;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(Position.X - 8, Position.Y - 8,  16, 16);
        }

        public override void Update(GameTime timer) {
            _texture.Update(timer);
        }

    }
}
