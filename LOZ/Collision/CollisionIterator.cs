﻿using System.Diagnostics;
using System.Collections.Generic;

namespace LOZ.Collision
{
    class CollisionIterator
    {
        private List<IGameObjects> _gameObjects;
        public CollisionIterator(List<IGameObjects> gameObjects)
        {
            _gameObjects = gameObjects;

        }
        public void Iterate()
        {
            CollisionDetection detect = new CollisionDetection();
            Debug.WriteLine("ENTERED@");

            foreach (IGameObjects obj1 in _gameObjects)
                {
                foreach (IGameObjects obj2 in _gameObjects)
                {
                    if(!(obj1.Equals(obj2))) {
                        Debug.WriteLine("ENTERED");
                        detect.CheckCollision(obj1, obj2);
                    }
                }

            }    
        }
    }
}
