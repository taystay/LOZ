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

        private void LoadAllItems()
        {
            gameObjects.Add(new ArrowItem(new Point(100, 100 + 50)));          
            gameObjects.Add(new Bow(new Point(200, 100 + 50)));
            gameObjects.Add(new Clock(new Point(300, 100 + 50)));
            gameObjects.Add(new Compass(new Point(400, 100 + 50)));
            gameObjects.Add(new Fairy(new Point(500, 100 + 50)));
            gameObjects.Add(new FireItem(new Point(600, 100 + 50)));
            gameObjects.Add(new Heart(new Point(700, 100 + 50)));
            gameObjects.Add(new HeartContainer(new Point(800, 100 + 50)));
            gameObjects.Add(new Key(new Point(900, 100 + 50)));
            gameObjects.Add(new Map(new Point(100, 200 + 50)));
            gameObjects.Add(new Rupee(new Point(200, 200 + 50)));
            gameObjects.Add(new Triforce(new Point(300, 200 + 50)));
        }

        private void PlaceRandomBlock(int x, int y, Random rand)
        {
            int r = rand.Next() % 8;
            IEnvironment block;
            switch(r)
            {
                case 1:
                    block = new BlackTileBlock(new Point(x, y));
                    break;
                case 2:
                    block = new BlueSandBlock(new Point(x, y));
                    break;
                case 3:
                    block = new BlueTriangleBlock(new Point(x, y));
                    break;
                case 4:
                    block = new DarkBlueBlock(new Point(x, y));
                    break;
                case 5:
                    block = new MulticoloredBlock1(new Point(x, y));
                    break;
                case 6:
                    block = new MulticoloredBlock2(new Point(x, y));
                    break;
                case 7:
                    block = new SolidBlueBlock(new Point(x, y));
                    break;
                default:
                    block = new StairsBlock(new Point(x, y));
                    break;
            }
            gameObjects.Add((IGameObjects)block);
        }

        private void LoadBorder(int width, int height, int dx)
        {
            Random random = new Random();
            int blockWidth = 48;

            int startx = 64;
            int starty = 64;
            for(int i = 0; i < width; i++)
            {
                PlaceRandomBlock(startx + blockWidth * i, starty, random);
            }   
            for (int i = 0; i < height; i++)
            {
                PlaceRandomBlock(startx , starty + blockWidth * i, random);
            }
            for (int i = 0; i < width; i++)
            {
                PlaceRandomBlock(startx + blockWidth * i, starty + blockWidth * (height - 1), random);
            }
            for (int i = 0; i < height; i++)
            {
                PlaceRandomBlock(startx + blockWidth * (width - 1), starty + blockWidth * i, random);
            }
        }

        private void LoadEnemiesForTesting()
        {
            gameObjects.Add(new Bat(new Point(600, 500)));
            gameObjects.Add(new Dragon(new Point(200, 500)));
            gameObjects.Add(new Jelly(new Point(1000, 500)));
            gameObjects.Add(new NPC(new Point(700, 300)));
            gameObjects.Add(new Skeleton(new Point(700, 500)));
            gameObjects.Add(new SpikeTrap(new Point(500, 400)));
        }

        public override void LoadContent(ContentManager Content)
        {
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            gameObjects = new List<IGameObjects>();
            coll = new CollisionIterator(gameObjects);
            

            Link = new Link(new Point(500, 500));
            gameObjects.Add((IGameObjects)Link);

            LoadAllItems();
            LoadBorder(30 ,15  , 48);
            LoadEnemiesForTesting();
        }
    }
}
