﻿using LOZ.GameState;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class LinkEnemyCollision
    {
        public static void Handle(CollisionSide side)
        {
            Room.Link.TakeDamage(1);

            if (side == CollisionSide.Top)
                Room.Link.KnockBack(new Point(0, -4));
            else if (side == CollisionSide.Bottom)
                Room.Link.KnockBack(new Point(0, 4));
            else if (side == CollisionSide.Left)
                Room.Link.KnockBack(new Point(-4, 0));
            else if (side == CollisionSide.Right)
                Room.Link.KnockBack(new Point(4, 0));
        }
    }
}
