using System.Collections.Generic;
using LOZ.GameState;
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
            ILink link = Room.Link;
            _gameObjects.Add(link);
           
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
            _gameObjects.Remove(link);
           
        }
    }
}
