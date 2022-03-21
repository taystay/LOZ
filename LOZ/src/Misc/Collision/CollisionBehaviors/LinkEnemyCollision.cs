using LOZ.GameState;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class LinkEnemyCollision
    {
        public static void Handle(CollisionSide side)
        {
            /*
            Room.Link.TakeDamage();

            if (side == CollisionSide.Top)
                Room.Link.KnockBack(new Point(0, -4));
            else if (side == CollisionSide.Bottom)
                Room.Link.KnockBack(new Point(0, 4));
            else if (side == CollisionSide.Left)
                Room.Link.KnockBack(new Point(-4, 0));
            else if (side == CollisionSide.Right)
                link.Position = new Point(linkPos.X + knockback, linkPos.Y);
            else if (side == CollisionSide.Bottom)
                link.Position = new Point(linkPos.X, linkPos.Y + knockback);
        }
    }
}
