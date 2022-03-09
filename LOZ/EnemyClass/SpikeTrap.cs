using LOZ.Factories;
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
            return new Hitbox(Position.X -10, Position.Y - 10,  32, 32);
        }

        public override void Update(GameTime timer) {
            _texture.Update(timer);
            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }
        }

    }
}
