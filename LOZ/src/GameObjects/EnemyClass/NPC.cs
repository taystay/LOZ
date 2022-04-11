using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;


namespace LOZ.EnemyClass
{
    class NPC : AbstractEnemy
    {

        public NPC(Point location)
        {
            Health = 10;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateNPC();
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 48 / 2 ,Position.Y - 48 / 2,48,48);
        }

        public override void Update(GameTime timer)
        {
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
