using LOZ.Factories;
using Microsoft.Xna.Framework;
using LOZ.Collision;
using LOZ.LinkClasses;
using LOZ.GameStateReference;

namespace LOZ.EnemyClass
{
    class SpikeTrap : AbstractEnemy
    {
        private const int attackSpeed = 4;
        private const int framesPerUpdate = 30;
        private int frameCounter = 0;
        public SpikeTrap(Point location) {
            _texture= EnemySpriteFactory.Instance.CreateTrap();
            Position = location;
            velocity = new Point();
        }
        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X -16, Position.Y - 16,  32, 32);
        }

        public void CheckAttack()
        {
            if (velocity.X != 0 || velocity.Y != 0) return;
            ILink link = RoomReference.GetLink();
            int dx = Position.X - link.Position.X;
            int dy = Position.Y - link.Position.Y;
            if (-5 <= dx && dx <= 5 && dy > 0)
                AttackDown();
            else if (-5 <= dx && dx <= 5 && dy < 0)
                AttackUp();
            else if (-5 <= dy && dy <= 5 && dx < 0)
                AttackRight();
            else if (-5 <= dy && dy <= 5 && dx > 0)
                AttackLeft();

        }
        public void AttackUp()
        {
            velocity = new Point(0, attackSpeed);
        }
        public void AttackRight()
        {
            velocity = new Point(attackSpeed, 0);
        }
        public void AttackLeft()
        {
            velocity = new Point(-attackSpeed, 0);
        }
        public void AttackDown()
        {
            velocity = new Point(0, -attackSpeed);
        }
        public override void Update(GameTime timer)
        {
            frameCounter++;
            _texture.Update(timer);
            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }
            Point p = Position;
            Position = new Point(p.X += velocity.X, p.Y + velocity.Y);
            if (frameCounter < framesPerUpdate) return;
            if (velocity.X < 0)
                velocity.X += 1;
            else if (velocity.X > 0)
                velocity.X -= 1;
            if (velocity.Y < 0)
                velocity.Y += 1;
            else if (velocity.Y > 0)
                velocity.Y -= 1;
            frameCounter = 0;
        }
    }
}
