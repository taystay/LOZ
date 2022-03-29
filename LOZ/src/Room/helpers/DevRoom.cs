using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.EnvironmentalClasses;
using LOZ.DungeonClasses;

namespace LOZ.GameState
{
    public class DevRoom : Room
    {
        public DevRoom()
        {
            LoadContent();
        }
        public override void LoadContent()
        {
            GameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(GameObjects);
            exterior = new ExteriorObject(DoorType.Door, DoorType.Wall, DoorType.Wall, DoorType.Wall, GameObjects);
            PlaceFloor();
            PlaceItemsForDev();         
        }
        private void PlaceFloor()
        {
            int x = Info.Inside.X + Info.BlockWidth / 2;
            int y = Info.Inside.Y + Info.BlockWidth / 2;
            for(int i = 0; i < 12; i ++)
                for(int j = 0; j < 7; j++)
                    GameObjects.Add(new SolidBlueBlock(new Point(x + Info.BlockWidth * i, y + Info.BlockWidth * j)));
        }

        private Point GetCoorPoint(double x, double y)
        {
            Point start = Info.Inside.Location;
            start.X += Info.BlockWidth / 2;
            start.Y += Info.BlockWidth / 2;

            start.X += (int)((double)Info.BlockWidth * x);
            start.Y += (int)((double)Info.BlockWidth * y);

            return start;
        }

        private void PlaceItemsForDev()
        {
            GameObjects.Add(new FireItem(GetCoorPoint(5.5, 6)));

            GameObjects.Add(new ArrowItem(GetCoorPoint(0,0)));
            GameObjects.Add(new Heart(GetCoorPoint(0, 3)));
            GameObjects.Add(new HeartContainer(GetCoorPoint(0, 6)));
            
            GameObjects.Add(new Bow(GetCoorPoint(3, 0)));
            GameObjects.Add(new Map(GetCoorPoint(3, 3)));
            GameObjects.Add(new Compass(GetCoorPoint(3, 6)));
            GameObjects.Add(new Key(GetCoorPoint(8, 0)));
            GameObjects.Add(new Rupee(GetCoorPoint(8, 3)));
            GameObjects.Add(new Sword(GetCoorPoint(8, 6)));
            GameObjects.Add(new Triforce(GetCoorPoint(11, 0)));
            GameObjects.Add(new Clock(GetCoorPoint(11, 3)));
            GameObjects.Add(new Fairy(GetCoorPoint(11, 6)));
        }
    }
}
