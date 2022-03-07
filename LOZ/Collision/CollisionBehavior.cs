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
            if(TypeC.Check(firstObject, typeof(ILink)))
            {
                LinkCollision(firstObject, secondObject, side);
            } else if (TypeC.Check(firstObject, typeof(IEnemy)))
            {
                EnemyCollision(firstObject, secondObject, side);
            }       
            else if (TypeC.CheckPair(firstObject, typeof(IPlayerProjectile), secondObject, typeof(IEnvironment)))
            {
                PlayerProjectileEnvironmentCollision.Handle(firstObject, secondObject);
            } 

        }
        public void EnemyCollision(IGameObjects firstObject, IGameObjects secondObject, CollisionSide side)
        {
            if (TypeC.Check(secondObject, typeof(IPlayerProjectile)))
            {
                PlayerProjectileEnemyCollision.Handle(secondObject, firstObject);
            }
            else if (TypeC.Check(secondObject, typeof(DoorCollider)))
            {
                DoorColliderEnemyCollision.Handle(firstObject, secondObject, side);
            }
            else if (TypeC.CheckPair(firstObject, typeof(IEnemy), secondObject, typeof(IEnvironment)))
            {
                EnemyEnviornmentCollision.Handle(firstObject, secondObject, side);
            }
        }
        public void LinkCollision(IGameObjects firstObject, IGameObjects secondObject, CollisionSide side)
        {
            if (TypeC.Check(secondObject, typeof(IEnvironment)))
            {
                LinkBlockCollision.Handle(firstObject, secondObject, side);
            }
            else if (TypeC.Check(secondObject, typeof(IProjectile)))
            {
                LinkProjectileCollision.Handle(secondObject);
            }
            else if (TypeC.Check(secondObject, typeof(IEnemy)))
            {
                LinkEnemyCollision.Handle();
            }
            else if (TypeC.Check(secondObject, typeof(IItem)))
            {
                LinkItemCollision.Handle(secondObject);
            }
            else if (TypeC.Check(secondObject, typeof(DoorCollider)))
            {
                DoorColliderLinkCollision.Handle(secondObject);
            }
            else if (TypeC.Check(secondObject, typeof(StairsBlock)))
            {
                CurrentRoom.Instance.MoveRoomDirection(0, 0, -1);
            }
        }

    }
}
