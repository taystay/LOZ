using System.Collections.Generic;
using LOZ.Room;
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
            ILink link = CurrentRoom.link;
           
            foreach (IGameObjects obj1 in _gameObjects)
            {
                foreach (IGameObjects obj2 in _gameObjects)
                {
                    if(!(obj1.Equals(obj2))) {
                        detect.CheckCollision(obj1, obj2);
                    }
                    if(TypeC.CheckPair(obj1, typeof(SpikeTrap), obj2, typeof(ILink)))
                    {
                        SpikeTrap t = (SpikeTrap)obj1;
                        t.CheckAttack();
                    }
                }

            }

            foreach(IGameObjects item in _gameObjects)
            {
                //detect.CheckCollision(item, link);
                detect.CheckCollision(link, item);
            }
           
        }
    }
}
