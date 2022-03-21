using System.Collections.Generic;
using LOZ.Collision;

namespace LOZ.GameState
{
    public class DungeonRoom : Room
    {
        public DungeonRoom(List<IGameObjects> list)
        {
            GameObjects = list;
            colliders = new CollisionIterator(GameObjects);
            
        }
        public override void LoadContent() {
            colliders = new CollisionIterator(GameObjects);

        }
    }
}
