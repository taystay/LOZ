using LOZ.ItemsClasses;
using LOZ.GameStateReference;
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
                RoomReference.GetLink().RaiseItem(item_user);

                RoomReference.GetInventory().AddItem(item);
            } else
            {
                if (TypeC.Check(item, typeof(LeftRightSwordHitBox)) || TypeC.Check(item, typeof(UpDownSwordHitBox))) return;
                if (side == CollisionSide.Top)
                    RoomReference.GetLink().KnockBack(new Point(0, -4));
                else if (side == CollisionSide.Bottom)
                    RoomReference.GetLink().KnockBack(new Point(0, 4));
                else if (side == CollisionSide.Left)
                    RoomReference.GetLink().KnockBack(new Point(-4, 0));
                else if (side == CollisionSide.Right)
                    RoomReference.GetLink().KnockBack(new Point(4, 0));
                RoomReference.GetLink().TakeDamage(1);
            }
        }
    }
}
