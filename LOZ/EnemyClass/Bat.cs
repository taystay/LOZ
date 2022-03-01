﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;

namespace LOZ.EnemyClass
{
    class Bat : AbstractEnemy
    {
        public Bat(Point location)
        {
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateBat();
            random = new Random();

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(Position.X-WidthSpriteSection/2, Position.Y - HeightSpriteSection/2 + 10, 67, 40);
        }

        public override void Update(GameTime timer)
        {
            if ((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                velocity.X = random.Next(-4, 4);
                velocity.Y = random.Next(-4, 4);
            }

            modifyPosition(velocity.X, velocity.Y);

            _texture.Update(timer);
        }

    }
}
