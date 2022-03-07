using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using LOZ.LinkClasses;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using System;
using LOZ.DungeonClasses;
using LOZ.SpriteClasses.BlockSprites;
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
            int x = DungeonInfo.Inside.X + 24;
            int y = DungeonInfo.Inside.Y + 24;
            for(int i = 0; i < 12; i ++)
                for(int j = 0; j < 7; j++)
                    gameObjects.Add(new SolidBlueBlock(new Point(x + 48 * i, y + 48 * j)));
        }

        private void IncrementPointX(Point p)
        {
            p.X += 48;
            p.Y += 48;
        }
        private void PlaceItemsForDev()
        {
            Point start = DungeonInfo.Inside.Location;
            start.X += 24;
            start.Y += 24;
            gameObjects.Add(new ArrowItem(start));
            start.Y += 48;
            gameObjects.Add(new Heart(start));
            start.Y += 48;
            gameObjects.Add(new HeartContainer(start));
            start.Y += 48;
            gameObjects.Add(new FireItem(start));
            start.Y += 48;
            gameObjects.Add(new Bow(start));
            start.Y += 48;
            gameObjects.Add(new Map(start));
            start.X += 48;
            gameObjects.Add(new Compass(start));
            start.X += 48;
            gameObjects.Add(new Key(start));
            start.X += 48;
            gameObjects.Add(new Rupee(start));
            start.X += 48;
            gameObjects.Add(new Sword(start));
            start.X += 48;
            gameObjects.Add(new Triforce(start));
            start.X += 48;
            gameObjects.Add(new Clock(start));
            start.X += 48;
            gameObjects.Add(new Fairy(start));
        }

    }
}
