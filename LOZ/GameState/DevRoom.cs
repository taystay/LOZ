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
            gameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(gameObjects);
            gameObjects.Add(new ExteriorObject(DoorType.Door, DoorType.Wall, DoorType.Wall, DoorType.Wall, gameObjects));
            PlaceFloor();
            PlaceItemsForDev();
            
        }
        private void PlaceFloor()
        {
            int x = Info.Inside.X + Info.BlockWidth / 2;
            int y = Info.Inside.Y + Info.BlockWidth / 2;
            for(int i = 0; i < 12; i ++)
                for(int j = 0; j < 7; j++)
                    gameObjects.Add(new SolidBlueBlock(new Point(x + Info.BlockWidth * i, y + Info.BlockWidth * j)));
        }

        private void PlaceItemsForDev()
        {
            Point start = Info.Inside.Location;
            start.X += Info.BlockWidth / 2;
            start.Y += Info.BlockWidth / 2;
            gameObjects.Add(new ArrowItem(start));
            start.Y += Info.BlockWidth;
            gameObjects.Add(new Heart(start));
            start.Y += Info.BlockWidth;
            gameObjects.Add(new HeartContainer(start));
            start.Y += Info.BlockWidth;
            gameObjects.Add(new FireItem(start));
            start.Y += Info.BlockWidth;
            gameObjects.Add(new Bow(start));
            start.Y += Info.BlockWidth;
            gameObjects.Add(new Map(start));
            start.X += Info.BlockWidth;
            gameObjects.Add(new Compass(start));
            start.X += Info.BlockWidth;
            gameObjects.Add(new Key(start));
            start.X += Info.BlockWidth;
            gameObjects.Add(new Rupee(start));
            start.X += Info.BlockWidth;
            gameObjects.Add(new Sword(start));
            start.X += Info.BlockWidth;
            gameObjects.Add(new Triforce(start));
            start.X += Info.BlockWidth;
            gameObjects.Add(new Clock(start));
            start.X += Info.BlockWidth;
            gameObjects.Add(new Fairy(start));
        }
    }
}
