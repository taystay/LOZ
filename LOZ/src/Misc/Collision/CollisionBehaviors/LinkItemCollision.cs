using LOZ.ItemsClasses;
using LOZ.GameState;

namespace LOZ.Collision
{
    public static class LinkItemCollision
    {
        public static void Handle(IGameObjects item)
        {
            IItem item_user = (IItem)item;
            if (!TypeC.Check(item, typeof(IPlayerProjectile)) && !TypeC.Check(item, typeof(FireItem)) && !TypeC.Check(item, typeof(FireProjectile)) && !TypeC.Check(item, typeof(Bomb)))
            {
                Room.Link.RaiseItem(item_user);
                Room.RoomInventory.AddItem(item);
            } else
            {
                Room.Link.TakeDamage(1);
            }
        }
    }
}
