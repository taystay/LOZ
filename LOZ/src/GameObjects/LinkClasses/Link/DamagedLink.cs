using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.GameStateReference;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.Sound;
using LOZ.Inventory;

namespace LOZ.LinkClasses
{
    class DamagedLink : ILink
    {
        private ILink decoratedLink;
        private int count = 60;

        public Point Position
        {
            get => decoratedLink.Position;
            set => decoratedLink.Position = value;
        }
        public int Health
        {
            get => decoratedLink.Health;
            set => decoratedLink.Health = value;
        }
        public int MaxHealth {
            get => decoratedLink.MaxHealth;
            set => decoratedLink.MaxHealth = value;
        }
        public LinkInventory Inventory {
            get => decoratedLink.Inventory;
            set => decoratedLink.Inventory = value;
        }
        public bool Damaged {
            get => decoratedLink.Damaged;
            set => decoratedLink.Damaged = value;
        }

        public DamagedLink(ILink decoratedLink, int damage)
        {
            RoomReference.GetLink().Health -= damage;
            SoundManager.Instance.SoundToPlayInstance(SoundEnum.Link_Hurt);
            this.decoratedLink = decoratedLink;
            RoomReference.GetLink().Damaged = true;
            if (RoomReference.GetLink().Health <= 2 && RoomReference.GetLink().Health > 0)
            {
                SoundManager.Instance.SoundToLoop(SoundEnum.LowHealth);
            }
            if(RoomReference.GetLink().Health <= 0)
            {
                SoundManager.Instance.SoundToNotLoop(SoundEnum.LowHealth);
                decoratedLink.Die();
            }
        }
        public bool IsActive() =>
            true;
        public void ChangeDirectionUp() =>
            decoratedLink.ChangeDirectionUp();
        public void ChangeDirectionDown() =>
            decoratedLink.ChangeDirectionDown();
        public void ChangeDirectionLeft() =>
            decoratedLink.ChangeDirectionLeft();
        public void ChangeDirectionRight() =>
            decoratedLink.ChangeDirectionRight();
        public void Move() =>
            decoratedLink.Move();     
        public void Idle() =>
            decoratedLink.Idle();
        public void RaiseItem(IItem item) =>
            decoratedLink.RaiseItem(item);
        public void Attack(Weapon currentUse) =>
            decoratedLink.Attack(currentUse);
        public void Die() =>
            decoratedLink.Die();
        public Point GetPosition() =>
            decoratedLink.GetPosition();
        public void ChangePosition(Point p) =>
            decoratedLink.ChangePosition(p);
        public Hitbox GetHitBox() =>
            new Hitbox(Position.X - 48 / 2 + 14, Position.Y - 48 / 2 + 14, 20, 20);

        public void KnockBack(Point vel) { }
        public void TakeDamage(int damage) { }
        public void Update(GameTime timer)
        {
            count--;
            if(count <= 0)
            {
                RemoveDecorator();
            }
            decoratedLink.Update(timer);
        }
        public void RemoveDecorator()
        {
            RoomReference.SetLink(decoratedLink);
            RoomReference.GetLink().Damaged = false;
        }
        public void Draw(SpriteBatch spriteBatch) =>
            decoratedLink.Draw(spriteBatch);
        public void Draw(SpriteBatch spriteBatch, Point offset) =>
            decoratedLink.Draw(spriteBatch, offset);
    }
}
