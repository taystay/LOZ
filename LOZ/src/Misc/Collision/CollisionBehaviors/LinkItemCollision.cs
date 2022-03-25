using LOZ.ItemsClasses;
using LOZ.GameState;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class LinkItemCollision
    {
        public static void Handle(IGameObjects item, CollisionSide side)
        {
            IItem item_user = (IItem)item;
            if (!TypeC.Check(item, typeof(IPlayerProjectile)) && !TypeC.Check(item, typeof(FireItem)) && !TypeC.Check(item, typeof(FireProjectile)) && !TypeC.Check(item, typeof(Bomb)))
            {
                if(!TypeC.Check(item, typeof(Rupee)) && !TypeC.Check(item, typeof(Heart)) && !TypeC.Check(item, typeof(ArrowItem)) && !TypeC.Check(item, typeof(Key)))
                {
                    Room.Link.RaiseItem(item_user);
                    Room.RoomInventory.AddItem(item);
                } else
                {
                    item_user.KillItem();
                    Room.RoomInventory.AddItem(item);
                }
            } else
            {
                if (side == CollisionSide.Top)
                    Room.Link.KnockBack(new Point(0, -4));
                else if (side == CollisionSide.Bottom)
                    Room.Link.KnockBack(new Point(0, 4));
                else if (side == CollisionSide.Left)
                    Room.Link.KnockBack(new Point(-4, 0));
                else if (side == CollisionSide.Right)
                    Room.Link.KnockBack(new Point(4, 0));
                Room.Link.TakeDamage(1);
            }
        }
    }
}
