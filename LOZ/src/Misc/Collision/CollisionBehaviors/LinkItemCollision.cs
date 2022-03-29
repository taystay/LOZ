﻿using LOZ.ItemsClasses;
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
                Room.Link.RaiseItem(item_user);
                Room.RoomInventory.AddItem(item);
            } else
            {
                if (TypeC.Check(item, typeof(LeftRightSwordHitBox)) || TypeC.Check(item, typeof(UpDownSwordHitBox))) return;
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
