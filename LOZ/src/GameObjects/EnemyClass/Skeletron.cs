using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.Collision;
using LOZ.GameStateReference;
using LOZ.SpriteClasses;

namespace LOZ.EnemyClass
{
    class Skeletron : AbstractEnemy
    {
        private const double vMag = 1.5;
        private protected Vector2 velocity2;
        private ISpriteRotatable head;
        private float rotation = 0.0f;
        public Skeletron(Point location)
        {
            Health = 1;
            Position = location;
            head = EnemySpriteFactory.Instance.CreateSkeletonHead();
            head.Scale = 4.0;
            velocity2 = new Vector2(0, 0);
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(Position.X - 15, Position.Y - 15, 30, 30);
        }

        public override void Update(GameTime timer)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            if (_keySprite == null && hasKey)
            {
                _keySprite = Factories.ItemFactory.Instance.CreateKeySprite();
                _keySprite.ChangeScale(1.0);
            }

            if (hasKey) _keySprite.Draw(spriteBatch, Position + offset);

            Color c = Color.White;
            if (IsDamaged)
                c = Color.Red;

            head.Draw(spriteBatch, Position, c, rotation);
            rotation += 0.1f;

        }
    }
}
