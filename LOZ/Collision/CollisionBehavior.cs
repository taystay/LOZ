using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using LOZ.EnemyClass.Projectiles;
using LOZ.GameState;

namespace LOZ.Collision
{
    class CollisionBehavior
    {
        public CollisionBehavior()
        {

        }

        public void HandleCollision(IGameObjects firstObject, IGameObjects secondObject, CollisionSide side)
        {
            if (TypeC.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IEnvironment)))
            {
                LinkBlockCollision.Handle(firstObject, secondObject, side);
            } 
            else if (TypeC.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IProjectile)))
            {
                LinkProjectileCollision.Handle(secondObject);
            }               
            else if (TypeC.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IEnemy)))
            {
                LinkEnemyCollision.Handle();
            }              
            else if (TypeC.CheckPair(firstObject, typeof(ILink), secondObject, typeof(IItem)))
            {
                LinkItemCollision.Handle(secondObject);
            }              
            else if (TypeC.CheckPair(firstObject, typeof(AbstractEnemy), secondObject, typeof(IEnvironment)))
            {
                EnemyEnviornmentCollision.Handle(firstObject, secondObject, side);
            }              
            else if (TypeC.CheckPair(firstObject, typeof(IPlayerProjectile), secondObject, typeof(IEnemy)))
            {
                PlayerProjectileEnemyCollision.Handle(firstObject, secondObject);
            }
            else if (TypeC.CheckPair(firstObject, typeof(IPlayerProjectile), secondObject, typeof(IEnvironment)))
            {
                PlayerProjectileEnvironmentCollision.Handle(firstObject, secondObject);
            }
            else if(TypeC.CheckPair(firstObject, typeof(DoorCollider), secondObject, typeof(ILink)))
            {
                DoorColliderLinkCollision.Handle( firstObject);
            }
            else if (TypeC.CheckPair(firstObject, typeof(DoorCollider), secondObject, typeof(IEnemy)))
            {
                DoorColliderEnemyCollision.Handle(firstObject, secondObject, side);
            } else
            {

            }

        }
    }
}
