using LOZ.ItemsClasses;
using LOZ.GameState;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class LinkItemCollision
    {
        public static void Handle(IGameObjects item)
        {
            IItem item_user = (IItem)item;
            if (!Type.Check(item, typeof(IPlayerProjectile)))
            {
                CurrentRoom.Room.Link.RaiseItem(item_user);
            }
        }
    }
}
