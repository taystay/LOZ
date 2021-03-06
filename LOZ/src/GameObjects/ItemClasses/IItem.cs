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
        public bool InventoryItem { get; set; }
        public void SetPositionOnUpdate(Point position);
        public void SetPosition(Point position);
        public void KillItem();
    }
}
