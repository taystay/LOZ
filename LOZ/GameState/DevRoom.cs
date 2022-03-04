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
            
        }

        public override void LoadContent()
        {
            gameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(gameObjects);
            Link = new Link(new Point(1000, 500));
            gameObjects.Add(Link);
            gameObjects.Add(new ExteriorObject(DoorType.Wall, DoorType.Wall, DoorType.Wall, DoorType.Wall, gameObjects));

            //PlaceFloor();
        }

        private void PlaceFloor()
        {
            int x = DungeonInfo.Inside.X + 24;
            int y = DungeonInfo.Inside.Y + 24;
            for(int i = 0; i < 12; i ++)
                for(int j = 0; j < 7; j++)
                    gameObjects.Add(new SolidBlueBlock(new Point(x + 48 * i, y + 48 * j)));
            

        }

    }
}
