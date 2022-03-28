using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.ItemsClasses;


namespace LOZ.LinkClasses
{
    public interface ILinkState
    {
        public void Up();
        public void Down();
        public void Left();
        public void Right();
        public void Move();
        public void Idle();
        public void Attack(Weapon toUse, Point position);
        public void KnockBack(Point vel);
        public void TakeDamage(int damage);
        public void Die();
        public void RaiseItem(IItem item);
        public void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch, Point Location);
    }
}

