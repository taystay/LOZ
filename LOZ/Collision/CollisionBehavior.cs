using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using LOZ.EnemyClass.Projectiles;

namespace LOZ.Collision
{
    class CollisionBehavior
    {
        public CollisionBehavior()
        {

        }

        public void HandleCollision(IGameObjects firstObject, IGameObjects secondObject, CollisionSide side)
        {
            if (Type.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IEnvironment)))
            {
                LinkBlockCollision.Handle(firstObject, secondObject, side);
            } 
            else if (Type.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IProjectile)))
            {
                LinkProjectileCollision.Handle(secondObject);
            }               
            else if (Type.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IEnemy)))
            {
                LinkEnemyCollision.Handle();
            }              
            else if (Type.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IItem)))
            {
                LinkItemCollision.Handle(secondObject);
            }              
            else if (Type.CheckPair(firstObject, typeof(AbstractEnemy), secondObject, typeof(IEnvironment)))
            {
                EnemyEnviornmentCollision.Handle(firstObject, secondObject, side);
            }              
            else if (Type.CheckPair(firstObject, typeof(IPlayerProjectile), secondObject, typeof(IEnemy)))
            {
                PlayerProjectileEnemyCollision.Handle(firstObject, secondObject);
            }
            else if (Type.CheckPair(firstObject, typeof(IPlayerProjectile), secondObject, typeof(IEnvironment)))
            {
                PlayerProjectileEnvironmentCollision.Handle(firstObject, secondObject);
            }

        }
    }
}
