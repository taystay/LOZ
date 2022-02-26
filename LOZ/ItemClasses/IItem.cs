using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Collision.Iterator;

namespace Sprint2.ItemsClasses
{

    public enum Direction
    {
        Up, 
        Left,
        Right,
        Down
    };

    interface IItem : IGameObjects
    {
        public Boolean SpriteActive();

    }
}
