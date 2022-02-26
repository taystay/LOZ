
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


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
        public void TakeDamage();
        public void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch, Point Location);
    }
}

