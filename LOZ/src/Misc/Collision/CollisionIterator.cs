using System.Collections.Generic;
using LOZ.GameStateReference;
using LOZ.LinkClasses;
using LOZ.EnemyClass;

namespace LOZ.Collision
{
    public class CollisionIterator
    {
        private List<IGameObjects> _gameObjects;
        public CollisionIterator(List<IGameObjects> gameObjects)
        {
            _gameObjects = gameObjects;

        }
        public void Iterate()
        {
            CollisionDetection detect = new CollisionDetection();
            ILink link = RoomReference.GetLink();
           
            foreach (IGameObjects obj1 in _gameObjects)
            {
                foreach (IGameObjects obj2 in _gameObjects)
                {
                    if(!(obj1.Equals(obj2))) {
                        detect.CheckCollision(obj1, obj2);
                    }
                    
                    
                }

            }

            foreach(IGameObjects item in _gameObjects)
            {
                detect.CheckCollision(link, item);
                if (TypeC.Check(item, typeof(SpikeTrap)))
                {
                    SpikeTrap t = (SpikeTrap)item;
                    t.CheckAttack();
                }
            }
           
        }
    }
}
