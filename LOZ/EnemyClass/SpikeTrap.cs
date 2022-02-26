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
            position = location;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(position.X - 8, position.Y - 8,  16, 16);
        }

        public override void Update(GameTime timer) {
            _texture.Update(timer);
        }

    }
}
