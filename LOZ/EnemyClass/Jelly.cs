﻿using System;
using LOZ.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.Collision;


namespace LOZ.EnemyClass
{
    class Jelly : AbstractEnemy
    {
        public Jelly(Point location)
        {
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateJelly();       
            random = new Random();
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - WidthSpriteSection / 2, Position.Y - HeightSpriteSection / 2, 16, 19);
        }

        public override void Update(GameTime timer)
        {
            if((int)timer.TotalGameTime.TotalMilliseconds % 1000 == 0)
            {
                velocity.X = random.Next(-4, 4);
                velocity.Y = random.Next(-4, 4);
            }

            modifyPosition(velocity.X, velocity.Y);

            _texture.Update(timer);
        }

    }
}
