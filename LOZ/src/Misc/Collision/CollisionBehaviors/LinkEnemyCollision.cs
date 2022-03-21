using LOZ.GameState;
using LOZ.LinkClasses;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class LinkEnemyCollision
    {
        public static void Handle(IGameObjects firstObj, CollisionSide side)
        {
            /*
            Room.Link.TakeDamage();
            ILink link = (ILink)firstObj;
            Point linkPos = link.Position;
            int knockback = 40;

            if (side == CollisionSide.Top)
                link.Position = new Point(linkPos.X, linkPos.Y - knockback);
            else if (side == CollisionSide.Left)
                link.Position = new Point(linkPos.X - knockback, linkPos.Y);
            else if (side == CollisionSide.Right)
                link.Position = new Point(linkPos.X + knockback, linkPos.Y);
            else if (side == CollisionSide.Bottom)
                link.Position = new Point(linkPos.X, linkPos.Y + knockback);
            */
        }
    }
}
