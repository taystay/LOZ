using LOZ.EnvironmentalClasses;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework;

namespace LOZ.Collision
{
    public static class PlayerProjectileEnvironmentCollision
    {
        public static void Handle(IGameObjects p, IGameObjects e, CollisionSide side)
        {
            IPlayerProjectile projectile = (IPlayerProjectile)p;
            IEnvironment environemnt = (IEnvironment)e;
            Rectangle projectileBox = projectile.GetHitBox().ToRectangle();
            Rectangle blockBox = environemnt.GetHitBox().ToRectangle();
            Rectangle collisionBox = Rectangle.Intersect(projectileBox, blockBox);

            if (TypeC.Check(environemnt, typeof(InvisibleBlock)) && !TypeC.Check(projectile, typeof(FireProjectile)))
                projectile.KillItem();

            if(TypeC.Check(projectile, typeof(FireProjectile)) && TypeC.Check(environemnt, typeof(InvisibleBlock)))
                if (side == CollisionSide.Top)
                    projectile.SetPosition(new Point(projectile._itemLocation.X, projectile._itemLocation.Y - collisionBox.Height));
                else if (side == CollisionSide.Left)
                    projectile.SetPosition(new Point(projectile._itemLocation.X - collisionBox.Width, projectile._itemLocation.Y));
                else if (side == CollisionSide.Right)
                    projectile.SetPosition(new Point(projectile._itemLocation.X + collisionBox.Width, projectile._itemLocation.Y));
                else if (side == CollisionSide.Bottom)
                    projectile.SetPosition(new Point(projectile._itemLocation.X, projectile._itemLocation.Y + collisionBox.Height));
        }
    }
}
