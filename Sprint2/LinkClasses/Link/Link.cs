
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.LinkClasses
{
    class Link : ILink
    {
        private Point Position { get; set; }
        public ILinkState linkState { get; set; }

        public Link(Point location)
        {

            Position = location;
            linkState = new DownIdleLinkState(Position, this);

        }
        public void ChangeDirectionUp()
        {
            linkState.Up();
        }

        public void ChangeDirectionDown()
        {
            linkState.Down();
        }

        public void ChangeDirectionLeft()
        {
            linkState.Left();
        }

        public void ChangeDirectionRight()
        {
            linkState.Right();
        }

        public void Move()
        {
            linkState.Move();
        }

        public void Idle()
        {
            linkState.Idle();
        }

        public void Attack(Weapon currentUse)
        {
            linkState.Attack(currentUse);
        }

        public void TakeDamage()
        {
            linkState.TakeDamage();
        }

        public Point GetPosition()
        {
            return Position;
        }

        public void Update(GameTime timer)
        {

            linkState.Update(timer);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            linkState.Draw(spriteBatch);

        }

    }
}
