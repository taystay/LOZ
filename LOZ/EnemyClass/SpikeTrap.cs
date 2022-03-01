using LOZ.SpriteClasses;
using LOZ.Factories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Collision;

namespace LOZ.EnemyClass
{
    class SpikeTrap : AbstractEnemy
    {
        public SpikeTrap(Point location) {
            _texture= EnemySpriteFactory.Instance.CreateTrap();
            Position = location;
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 8, Position.Y - 8,  16, 16);
        }

        public override void Update(GameTime timer) {
            _texture.Update(timer);
        }

    }
}
