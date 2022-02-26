using System;
using LOZ.Collision.Iterator;

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
        public Boolean SpriteActive();

    }
}
