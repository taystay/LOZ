using LOZ.Room;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class LinkEnemyCollision
    {
        public static void Handle(CollisionSide side)
        {
            CurrentRoom.link.TakeDamage(1);

            if (side == CollisionSide.Top)
                CurrentRoom.link.KnockBack(new Point(0, -4));
            else if (side == CollisionSide.Bottom)
                CurrentRoom.link.KnockBack(new Point(0, 4));
            else if (side == CollisionSide.Left)
                CurrentRoom.link.KnockBack(new Point(-4, 0));
            else if (side == CollisionSide.Right)
                CurrentRoom.link.KnockBack(new Point(4, 0));
        }
    }
}
