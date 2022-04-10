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
        private List<IGameObjects> roomObj;
        public DevRoom()
        {
            LoadContent();
        }
        public void LoadContent()
        {
            roomObj = new List<IGameObjects>();
            colliders = new CollisionIterator(roomObj);
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Wall, DoorType.Wall, DoorType.Wall, roomObj);
            PlaceFloor();
            PlaceItemsForDev();
        }
        private void PlaceFloor()
        {
            int x = Info.Inside.X + Info.BlockWidth / 2;
            int y = Info.Inside.Y + Info.BlockWidth / 2;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 7; j++)
                    roomObj.Add(new SolidBlueBlock(new Point(x + Info.BlockWidth * i, y + Info.BlockWidth * j)));
        }

        private void PlaceItemsForDev()
        {
            roomObj.Add(new FireItem(GetCoorPoint(5.5, 6)));
            roomObj.Add(new PortalGun(GetCoorPoint(5.5, 0)));

            roomObj.Add(new ArrowItem(GetCoorPoint(0, 0)));
            roomObj.Add(new Heart(GetCoorPoint(0, 3)));
            roomObj.Add(new HeartContainer(GetCoorPoint(0, 6)));


            roomObj.Add(new Bow(GetCoorPoint(3, 0)));
            roomObj.Add(new Map(GetCoorPoint(3, 3)));
            roomObj.Add(new Compass(GetCoorPoint(3, 6)));
            roomObj.Add(new Key(GetCoorPoint(8, 0)));
            roomObj.Add(new Rupee(GetCoorPoint(8, 3)));
            roomObj.Add(new Sword(GetCoorPoint(8, 6)));
            roomObj.Add(new Triforce(GetCoorPoint(11, 0)));
            roomObj.Add(new Clock(GetCoorPoint(11, 3)));
            roomObj.Add(new Fairy(GetCoorPoint(11, 6)));
        }
    }
}
