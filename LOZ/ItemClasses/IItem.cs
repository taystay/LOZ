using System;
using LOZ.Collision;

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
        public void KillItem();
        public Boolean SpriteActive();

    }
}
