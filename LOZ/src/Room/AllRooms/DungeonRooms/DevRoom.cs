using Microsoft.Xna.Framework;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.ItemsClasses;
using LOZ.EnvironmentalClasses;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class DevRoom : RoomAbstract
    {
        public DevRoom()
        {
            LoadContent();
        }
        public void LoadContent()
        {
            gameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(gameObjects);
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Wall, DoorType.Wall, DoorType.Wall, gameObjects);
            PlaceFloor();
            PlaceItemsForDev();
        }
        private void PlaceFloor()
        {
            int x = Info.Inside.X + Info.BlockWidth / 2;
            int y = Info.Inside.Y + Info.BlockWidth / 2;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 7; j++)
                    gameObjects.Add(new SolidBlueBlock(new Point(x + Info.BlockWidth * i, y + Info.BlockWidth * j)));
        }

        private void PlaceItemsForDev()
        {
            gameObjects.Add(new FireItem(GetCoorPoint(5.5, 6)));
            gameObjects.Add(new PortalGun(GetCoorPoint(5.5, 0)));

            gameObjects.Add(new ArrowItem(GetCoorPoint(0, 0)));
            gameObjects.Add(new Heart(GetCoorPoint(0, 3)));
            gameObjects.Add(new HeartContainer(GetCoorPoint(0, 6)));


            gameObjects.Add(new Bow(GetCoorPoint(3, 0)));
            gameObjects.Add(new Map(GetCoorPoint(3, 3)));
            gameObjects.Add(new Compass(GetCoorPoint(3, 6)));
            gameObjects.Add(new Key(GetCoorPoint(8, 0)));
            gameObjects.Add(new Rupee(GetCoorPoint(8, 3)));
            gameObjects.Add(new Sword(GetCoorPoint(8, 6)));
            gameObjects.Add(new Triforce(GetCoorPoint(11, 0)));
            gameObjects.Add(new Clock(GetCoorPoint(11, 3)));
            gameObjects.Add(new Fairy(GetCoorPoint(11, 6)));
        }
    }
}
