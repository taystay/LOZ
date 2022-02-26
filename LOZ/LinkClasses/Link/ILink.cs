using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.LinkClasses
{
    public enum Weapon : int
    {
        Swordbeam,
        Arrow,
        Bomb,
        Fire,
        Default
    }
    public interface ILink
    {
        public Point Position { get; set; }
        public void ChangeDirectionUp();
        public void ChangeDirectionDown();
        public void ChangeDirectionLeft();
        public void ChangeDirectionRight();
        public void Move();
        public void Idle();
        public void Attack(Weapon currentUse);
        public void TakeDamage();
        public Point GetPosition();
        public void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch);
    }
}
