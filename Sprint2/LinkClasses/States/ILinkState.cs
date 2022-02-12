using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Sprint2
{
    public interface ILinkState
    {
        public void ChangeDirectionUp();
        public void ChangeDirectionDown();
        public void ChangeDirectionLeft();
        public void ChangeDirectionRight();
        public void Move();
        public void Idle();
        public void Attack();
        public void TakeDamage();
        public void Update(GameTime timer);
        public void Draw(SpriteBatch spriteBatch);
    }
}

