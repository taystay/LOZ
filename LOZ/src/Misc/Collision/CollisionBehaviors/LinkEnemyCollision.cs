using LOZ.GameStateReference;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class LinkEnemyCollision
    {
        public static void Handle(CollisionSide side)
        {
            RoomReference.GetLink().TakeDamage(1);

            if (side == CollisionSide.Top)
                RoomReference.GetLink().KnockBack(new Point(0, -4));
            else if (side == CollisionSide.Bottom)
                RoomReference.GetLink().KnockBack(new Point(0, 4));
            else if (side == CollisionSide.Left)
                RoomReference.GetLink().KnockBack(new Point(-4, 0));
            else if (side == CollisionSide.Right)
                RoomReference.GetLink().KnockBack(new Point(4, 0));
        }
    }
}
