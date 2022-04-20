using System;
using Microsoft.Xna.Framework;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameStateReference;

namespace LOZ.EnemyClass
{
    class Bat : AbstractEnemy
    {
        private const double vMag = 1.5;
        private protected Vector2 velocity2;
        private const int framesPerUpdate = UpdateSpeed.BatUpdate;
        private int frameCounter = 0;
        public Bat(Point location)
        {
            Health = 1;
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateBat();
            velocity2 = new Vector2(0, 0);
        }

        public Bat(Point location, bool key) : this(location) =>
            hasKey = key;
        public override Hitbox GetHitBox() =>
            new Hitbox(Position.X - 15, Position.Y - 15, 30, 30);
        public override void Update(GameTime timer)
        {
            frameCounter++;
            if (frameCounter >= framesPerUpdate)
            {
                Point linkP = RoomReference.GetLink().Position;
                if (random.Next(2) % 3 != 0)
                {
                    double dx = (linkP.X - Position.X);
                    double dy = (linkP.Y - Position.Y);

                    double mag = Math.Sqrt(dx * dx + dy * dy);

                    dx = dx * vMag / mag;
                    dy = dy * vMag / mag;
                    velocity2.X = (float)dx;
                    velocity2.Y = (float)dy;
                } else
                {
                    double dx = random.Next(-2,2);
                    double dy = random.Next(-2,2);
                    velocity2.X = (float)dx;
                    velocity2.Y = (float)dy;
                }
                frameCounter = 0;
            }
            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }
            modifyPosition((int)velocity2.X, (int)velocity2.Y);
            _texture.Update(timer);
        }

    }
}
