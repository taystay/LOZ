using LOZ.Factories;
using Microsoft.Xna.Framework;
using LOZ.Collision;
using LOZ.LinkClasses;
using LOZ.GameStateReference;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using System;

namespace LOZ.EnemyClass
{
    class GhostGuy : AbstractEnemy
    {
        private const double vMag = 1.1;
        private protected Vector2 velocity2;
        private ISpriteRotatable sprite;
        private float rotation = 0.0f;
        private const float radiansInCircle = 6.283f;
        public GhostGuy(Point location)
        {
            Health = 10;
            Position = location;
            sprite = EnemySpriteFactory.Instance.CreateGhost();
        }
        public override Hitbox GetHitBox() =>
            new Hitbox(Position.X - 24 / 2, Position.Y - 24 / 2, 24, 24);
        public override void Update(GameTime timer)
        {
            sprite.Update(timer);
            Point linkP = RoomReference.GetLink().Position;
            double dx = (linkP.X - Position.X);
            double dy = (linkP.Y - Position.Y);
            double mag = Math.Sqrt(dx * dx + dy * dy);
            dx = dx * vMag / mag;
            dy = dy * vMag / mag;
            velocity2.X = (float)dx;
            velocity2.Y = (float)dy;
            modifyPosition((int)velocity2.X, (int)velocity2.Y);

            rotation += .1f;
            if (rotation > radiansInCircle)
                rotation = .1f;
        }

        public override void TakeDamage(int damage) { }

        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            if (_keySprite == null && hasKey)
            {
                _keySprite = Factories.ItemFactory.Instance.CreateKeySprite();
                _keySprite.ChangeScale(1.0);
            }

            if (hasKey) _keySprite.Draw(spriteBatch, Position + offset);

            if (IsDamaged)
                sprite.Draw(spriteBatch, Position + offset, Color.Red, rotation);
            else
                sprite.Draw(spriteBatch, Position + offset, rotation);
        }
    }
}
