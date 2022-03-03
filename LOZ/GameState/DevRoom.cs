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
namespace LOZ.GameState
{
    public class DevRoom : Room
    {
        public DevRoom()
        {
            
        }

        public override void LoadContent()
        {
            gameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(gameObjects);
            Link = new Link(new Point(1000, 500));
            gameObjects.Add(Link);
            gameObjects.Add(new ExteriorObject());

            PlaceFloor();
            PlaceDoors();
        }

        private void PlaceDoors()
        {
            Point location = DungeonInfo.Map.Location;
            location.X += DungeonInfo.DoorToCornerWidth;
            gameObjects.Add(new DoorObject(location,1));

            location = DungeonInfo.Map.Location;
            location.Y += DungeonInfo.DoorToCornerHeight;
            gameObjects.Add(new DoorObject(location, 2));

            location = DungeonInfo.Map.Location;
            location.X += DungeonInfo.DoorToCornerWidth;
            location.Y += DungeonInfo.DungeonHeight - DungeonInfo.DoorHeight;
            gameObjects.Add(new DoorObject(location, 4));

            location = DungeonInfo.Map.Location;
            location.Y += DungeonInfo.DoorToCornerHeight;
            location.X += DungeonInfo.DungeonWidth - DungeonInfo.DoorWidth;
            gameObjects.Add(new DoorObject(location, 3));

        }

        private void PlaceFloor()
        {
            int x = DungeonInfo.Inside.X + 24;
            int y = DungeonInfo.Inside.Y + 24;
            for(int i = 0; i < 12; i ++)
                for(int j = 0; j < 7; j++)
                    gameObjects.Add(new SolidBlueBlock(new Point(x + 48 * i, y + 48 * j)));

            x = x - 48;
            y = y - 48;

            for(int i = 0; i < 12; i++)
                gameObjects.Add(new InvisibleBlock(new Point(x + 48 + 48 * i, y)));


            for (int i = 0; i < 12; i++)
                gameObjects.Add(new InvisibleBlock(new Point(x + 48 + 48 * i, y + 8 * 48)));
             
            for (int i = 0; i < 7; i++)
                gameObjects.Add(new InvisibleBlock(new Point(x, y + 48 + i * 48)));

            for (int i = 0; i < 7; i++)
                gameObjects.Add(new InvisibleBlock(new Point(x + 13 * 48, y + 48 + i * 48)));
            

        }

    }
}
