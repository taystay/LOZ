using System;
using LOZ.Collision;
using Microsoft.Xna.Framework;

namespace LOZ.ItemsClasses
{

    public enum Direction
    {
        Up, 
        Left,
        Right,
        Down
    };

    public interface IItem : IGameObjects
    {
        
        public void SetPosition(Point position);
        public void KillItem();
        public Boolean SpriteActive();

    }
}
