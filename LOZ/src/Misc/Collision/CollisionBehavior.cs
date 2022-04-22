using LOZ.LinkClasses;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using LOZ.EnemyClass.Projectiles;
using LOZ.GameState;
using LOZ.GameStateReference;
using LOZ.CommandClasses.RoomCommands;
using LOZ.CommandClasses;

namespace LOZ.Collision
{
    class CollisionBehavior
    {
        public CollisionBehavior() { }
        public void HandleCollision(IGameObjects firstObject, IGameObjects secondObject, CollisionSide side)
        {

            if (TypeC.Check(secondObject, typeof(DoorCollider)))
            {
                DoorCollider d = (DoorCollider)secondObject;
                d.Collision(firstObject);
                if(TypeC.Check(firstObject, typeof(IPlayerProjectile)))
                {
                    IPlayerProjectile p = (IPlayerProjectile)firstObject;
                    p.KillItem();
                }
            }
            if(TypeC.Check(secondObject, typeof(Portal)) && TypeC.Check(firstObject, typeof(IEnvironment)))
            {
                Portal p = (Portal)secondObject;
                int status = 0;
                if(!p.hasCollided)
                    status = p.Collide();
                if (status == -1) RoomReference.GetCurrRoom().RemovedInDetection.Add(p);
            }
            if(TypeC.Check(secondObject, typeof(Portal)))
            {
                if (!TypeC.Check(firstObject, typeof(ILink)) && !TypeC.Check(firstObject, typeof(IItem))) return;
                Portal p = (Portal)secondObject;
                PortalManager.MoveThroughPortal(p, firstObject);
            }
            if (TypeC.Check(firstObject, typeof(ILink)))
                LinkCollision(firstObject, secondObject, side);
            else if (TypeC.Check(firstObject, typeof(IEnemy)))
                EnemyCollision(firstObject, secondObject, side);
            else if (TypeC.CheckPair(firstObject, typeof(IEnvironment), secondObject, typeof(IEnvironment)))    
                BlockBlockCollision.Handle(firstObject, secondObject, side);
            else if (TypeC.CheckPair(firstObject, typeof(IPlayerProjectile), secondObject, typeof(IEnvironment)))
                PlayerProjectileEnvironmentCollision.Handle(firstObject, secondObject, side);
            else if (TypeC.CheckPair(firstObject, typeof(IProjectile), secondObject, typeof(IEnvironment)))
                EnemyProjectileEnvironmentCollision.Handle(firstObject, secondObject, side);
        }
        public void EnemyCollision(IGameObjects firstObject, IGameObjects secondObject, CollisionSide side)
        {
            if (TypeC.Check(secondObject, typeof(IPlayerProjectile)))
                PlayerProjectileEnemyCollision.Handle(secondObject, firstObject, side);
            else if (TypeC.Check(secondObject, typeof(DoorCollider)))
                DoorColliderEnemyCollision.Handle(firstObject, secondObject, side);
            else if (TypeC.CheckPair(firstObject, typeof(IEnemy), secondObject, typeof(IEnvironment)))
                EnemyEnviornmentCollision.Handle(firstObject, secondObject, side);
        }
        public void LinkCollision(IGameObjects firstObject, IGameObjects secondObject, CollisionSide side)
        {       
            if (TypeC.Check(secondObject, typeof(IEnvironment)))
                LinkBlockCollision.Handle(firstObject, secondObject, side);
            else if (TypeC.Check(secondObject, typeof(IProjectile)))
                LinkProjectileCollision.Handle(secondObject);
            else if (TypeC.Check(secondObject, typeof(IEnemy)))
                LinkEnemyCollision.Handle(side);
            else if (TypeC.Check(secondObject, typeof(IItem)))
                LinkItemCollision.Handle(secondObject, side);
            if (TypeC.Check(secondObject, typeof(Bomb)) || TypeC.Check(secondObject, typeof(FireProjectile)))
                RoomReference.GetLink().TakeDamage(1);
        }
    }
}
