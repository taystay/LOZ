using LOZ.MapIO;
using LOZ.Collision;
using LOZ.EnemyClass;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room24 : RoomAbstract
    {
        private bool updated = false;
        public Room24(string pathFile)
        {
            
            gameObjects = IO.Instance.ParseRoom(pathFile + "2_4.csv");
            gameObjects.Add(new Bat(GetCoorPoint(9, 1)));
            gameObjects.Add(new Bat(GetCoorPoint(1, 4)));
            gameObjects.Add(new Bat(GetCoorPoint(2, 6)));
            gameObjects.Add(new Bat(GetCoorPoint(4, 3)));
            gameObjects.Add(new Bat(GetCoorPoint(4, 5)));
            gameObjects.Add(new Bat(GetCoorPoint(9, 6)));
            exterior = new ExteriorObject(DoorType.KeyDoor, DoorType.CrackedDoor, DoorType.Wall, DoorType.Wall, gameObjects);

            colliders = new CollisionIterator(gameObjects);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateNormally(gameTime);
            if (updated) return;
            foreach(IGameObjects obj in gameObjects)
            {
                if(TypeC.Check(obj, typeof(IEnemy)))
                {
                    return;
                }
            }
            exterior.ChangeDoorOnUpdate(DoorLocation.Right, DoorType.Door);
            updated = true;
        }
    }
}
