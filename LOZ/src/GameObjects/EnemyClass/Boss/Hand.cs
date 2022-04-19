using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameStateReference;
using LOZ.SpriteClasses;
using System.Collections.Generic;

namespace LOZ.EnemyClass
{
    class Hand : AbstractEnemy
    {
        private Color c = Color.White;
        private ISpriteRotatable hand;

        #region physics
        private const float mass = 30f;
        private const float dt = 1f;
        private const float slowDown = 100f;
        private protected Vector2 velocity2 = new Vector2();   
        #endregion

        public Hand(Point location, bool leftHand)
        {
            Health = 7;
            Position = location;
            hand = EnemySpriteFactory.Instance.CreateSkeletronHand(leftHand);
            hand.Scale = 3.0;
            velocity2 = new Vector2(0, 0);
        }

        public override Hitbox GetHitBox() => new Hitbox(Position.X - 15, Position.Y - 15, 30, 30);
        public void AddForce(Vector2 f)
        {
            velocity2.X += f.X/mass * dt;
            velocity2.Y += f.Y/mass * dt;
            
        }
        public override void Update(GameTime timer)
        {
            velocity2.X -= velocity2.X / slowDown;
            velocity2.Y -= velocity2.Y / slowDown;
            Position = new Point(Position.X + (int)(velocity2.X * dt), Position.Y + (int)(velocity2.Y * dt));
            if (IsDamaged)
            {
                timeLeftDamage--;
                if (timeLeftDamage <= 0)
                    IsDamaged = false;
            }
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            double angle = Math.Atan2(-velocity2.Y ,velocity2.X);
            if (IsDamaged)
                c = Color.Red;
            else
                c = Color.White;
            hand.Draw(spriteBatch, Position + offset, c, (float)angle);     
        }
    }
}
