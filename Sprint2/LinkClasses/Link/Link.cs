
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.LinkClasses
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
