using System;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.CommandClasses;

namespace LOZ.GameState
{
    public class DoorCollider : IGameObjects
    {
        private Hitbox box;
        private ICommand _command;
        private Type _responseType;
        public DoorCollider(Rectangle r, ICommand command, System.Type responseType)
        {
            box = new Hitbox(r.X, r.Y, r.Width, r.Height);
            _command = command;
            _responseType = responseType;
        }
        public Hitbox GetHitBox() => box;
        public bool IsActive() { return true; }
        public void Collision(IGameObjects o)
        {
            if (TypeC.Check(o, _responseType))
                _command.execute();
        }
        public void Update(GameTime gameTime) { }
        public void Draw(SpriteBatch spriteBatch){ }
        public void Draw(SpriteBatch spriteBatch, Point offset) { }
    }
}
