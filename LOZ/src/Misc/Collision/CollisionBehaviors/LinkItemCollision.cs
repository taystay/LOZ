using LOZ.ItemsClasses;
using LOZ.Room;
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
                CurrentRoom.link.RaiseItem(item_user);
                CurrentRoom.link.

                Room.RoomInventory.AddItem(item);
            } else
            {
                if (TypeC.Check(item, typeof(LeftRightSwordHitBox)) || TypeC.Check(item, typeof(UpDownSwordHitBox))) return;
                if (side == CollisionSide.Top)
                    CurrentRoom.link.KnockBack(new Point(0, -4));
                else if (side == CollisionSide.Bottom)
                    CurrentRoom.link.KnockBack(new Point(0, 4));
                else if (side == CollisionSide.Left)
                    CurrentRoom.link.KnockBack(new Point(-4, 0));
                else if (side == CollisionSide.Right)
                    CurrentRoom.link.KnockBack(new Point(4, 0));
                CurrentRoom.link.TakeDamage(1);
            }
        }
    }
}
