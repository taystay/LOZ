using System.Collections.Generic;
using LOZ.Collision;
namespace LOZ.GameState
{
    public class DungeonRoom : Room
    {
        public DungeonRoom(List<IGameObjects> list)
        {
            gameObjects = list;
        }

        public override void LoadContent() { }
    }
}
