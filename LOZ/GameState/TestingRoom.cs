using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using LOZ.LinkClasses;
using LOZ.ItemsClasses;
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
        public override void LoadContent(ContentManager Content)
        {
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            gameObjects = new List<IGameObjects>();
            Link = new Link(new Point(500, 500));
            gameObjects.Add(new ArrowDownItem(new Point(500, 0)));
        }
    }
}
