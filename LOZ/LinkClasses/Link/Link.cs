
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Collision;
using LOZ.ItemsClasses;

namespace LOZ.LinkClasses
{
    class Link : ILink
    {
        public Point Position { get; set; }
        public ILinkState LinkState { get; set; }

        public Link(Point location)
        {
            Position = location;
            LinkState = new DownIdleLinkState(this);
        }
        public void ChangeDirectionUp()
        {
            LinkState.Up();
        }

        public void ChangeDirectionDown()
        {
            LinkState.Down();
        }

        public void ChangeDirectionLeft()
        {
            LinkState.Left();
        }

        public void ChangeDirectionRight()
        {
            LinkState.Right();
        }

        public void Move()
        {
            LinkState.Move();
        }

        public void Idle()
        {
            LinkState.Idle();
        }

        public void RaiseItem(IItem item)
        {
            LinkState.RaiseItem(item);
        }

        public void Attack(Weapon currentUse)
        {
            LinkState.Attack(currentUse, Position);
        }

        public void TakeDamage()
        {
            LinkState.TakeDamage();
        }

        public Point GetPosition()
        {
            return Position;
        }

        public Hitbox GetHitBox()
        {
            Hitbox hitbox = new Hitbox(Position.X - 48 / 2 - 2 + 4, Position.Y - 48 / 2 + 4, 40, 40);
            return hitbox;
        }

        public void Update(GameTime timer)
        {

            LinkState.Update(timer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            LinkState.Draw(spriteBatch, Position);

        }

    }
}
