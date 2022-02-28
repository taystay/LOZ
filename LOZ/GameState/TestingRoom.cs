using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using LOZ.LinkClasses;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.EnemyClass;
using LOZ.EnemyClass.Projectiles;
using LOZ.Collision;

namespace LOZ.GameState
{
    class TestingRoom : Room
    {
        private static TestingRoom instance = new TestingRoom();
        public static TestingRoom Instance
        {
            get
            {
                return instance;
            }
        }
        private TestingRoom()
        {
            
        }

        private void LoadItemsForTesting()
        {
            gameObjects.Add(new ArrowItem(new Point(100, 100)));
            gameObjects.Add(new Bow(new Point(200, 100)));
            gameObjects.Add(new Clock(new Point(300, 100)));
            gameObjects.Add(new Compass(new Point(400, 100)));
            gameObjects.Add(new Fairy(new Point(500, 100)));
            gameObjects.Add(new FireItem(new Point(600, 100)));
            gameObjects.Add(new Heart(new Point(700, 100)));
            gameObjects.Add(new HeartContainer(new Point(800, 100)));
            gameObjects.Add(new Key(new Point(900, 100)));
            gameObjects.Add(new Map(new Point(100, 200)));
            gameObjects.Add(new Rupee(new Point(200, 200)));
            gameObjects.Add(new Triforce(new Point(300, 200)));
        }

        private void LoadBlocksForTesting()
        {

        }

        private void LoadEnemiesForTesting()
        {
            gameObjects.Add(new Bat(new Point(600, 500)));
            gameObjects.Add(new Dragon(new Point(200, 500), projectiles));
            gameObjects.Add(new Jelly(new Point(1000, 500)));
            gameObjects.Add(new NPC(new Point(800, 500)));
            gameObjects.Add(new Skeleton(new Point(700, 500)));
            gameObjects.Add(new SpikeTrap(new Point(1000, 900)));
        }

        public override void LoadContent(ContentManager Content)
        {
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            gameObjects = new List<IGameObjects>();
            projectiles = new List<IProjectile>();
            CollisionIterator collisions = new CollisionIterator(gameObjects);

            Link = new Link(new Point(500, 500));
            gameObjects.Add((IGameObjects)Link);

            LoadItemsForTesting();
            LoadBlocksForTesting();
            LoadEnemiesForTesting();
        }
    }
}
