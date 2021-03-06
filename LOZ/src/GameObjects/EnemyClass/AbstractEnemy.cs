using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using System;
using LOZ.Collision;
using LOZ.GameStateReference;
using LOZ.ItemsClasses;
using LOZ.Sound;

namespace LOZ.EnemyClass
{
    abstract class AbstractEnemy : IEnemy
    {
        #region public variables
        public bool IsDamaged { get; set; }
        public Point Position { get; set; }
        public int Health { get; set; } = 6;
        public Point knockBackVel = new Point(0, 0);
        public bool hasKey { get; set; } = false;
        #endregion

        #region static variables
        protected static int knockBackDuration = 20;
        protected static int currentKnockBack = 0;
        protected static bool knockedBack = false;
        #endregion

        #region constants
        private protected const int HeightSpriteSection = 83;
        private protected const int WidthSpriteSection = 64;
        private protected const int InivincibilityFrames = 40;
        #endregion

        private protected int timeLeftDamage = 20;
        private protected ISprite _texture;
        private protected ISprite _keySprite;
        private protected Point velocity;
        private protected Random random = new Random();
        private protected bool isActive = true;
        
        public void KillItem() =>
            isActive = false;
        public virtual void TakeDamage(int damage)
        {
            if(!IsDamaged)
            {
                IsDamaged = true;
                Health -= damage;
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Enemy_Hit);
                timeLeftDamage = InivincibilityFrames;
            } 
        }
        public virtual bool IsActive()
        {
            if (Health <= 0)
            {
                if(RoomReference.GetHardMode())
                    RoomReference.AddItem(new GhostGuy(Position));

                int num = random.Next();
                if (num % 2 == 0)
                {
                    RoomReference.AddItem(new Rupee(Position));
                      
                } else if (num % 3 == 2)
                {
                    RoomReference.AddItem(new Clock(Position));
                }
                else if (num % 4 == 0)
                {
                    RoomReference.AddItem(new Fairy(Position));
                }

                if(hasKey)
                {
                    RoomReference.AddItem(new Key(Position));
                }
                SoundManager.Instance.SoundToPlayInstance(SoundEnum.Enemy_Die);
                return false;
            }          
            return isActive;
        }
        protected void modifyPosition(int dx, int dy)
        {
            if (RoomReference.GetInventory().HasItem(typeof(Clock))) return;
            Position = new Point(Position.X + dx, Position.Y + dy);
        }
        public abstract Hitbox GetHitBox();
        public void KnockBack(Point vel)
        {
            if (!knockedBack)
            {
                knockedBack = true;
                knockBackVel = vel;
                return;
            }
        }
        public abstract void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch) =>
            Draw(spriteBatch, new Point());

        public virtual void Draw(SpriteBatch spriteBatch, Point offset)
        {
            if (_keySprite == null && hasKey)
            {
                _keySprite = Factories.ItemFactory.Instance.CreateKeySprite();
                _keySprite.ChangeScale(1.0);
            }

            if (hasKey) _keySprite.Draw(spriteBatch, Position + offset);

            if (IsDamaged)
                _texture.Draw(spriteBatch, Position + offset, Color.Red);
            else
                _texture.Draw(spriteBatch, Position + offset);          
        }
    }
}
