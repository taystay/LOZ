using System;
using System.Collections.Generic;
using System.Text;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.GameState
{
    public class DoorCollider : IGameObjects
    {
        private Hitbox box;
        public DoorCollider(int x, int y, int width, int height)
        {
            box = new Hitbox(x, y, width, height);
        }
        public Hitbox GetHitBox()
        {
            return box;
        }
        public void Update(GameTime gameTime)
        {
            //nothing
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //nothing
        }
    }
}
