using System.Collections.Generic;
using LOZ.Collision;

namespace LOZ.GameState
{
    public class DungeonRoom : OldRoom
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
