using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Factories;
using Sprint2.LinkClasses;
using Sprint2.ItemsClasses;

namespace LOZ.GameState
{
    class TestingRoom : Room
    {
        public override void LoadContent(ContentManager Content)
        {
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            IItem item = new ArrowDownItem(new Point(500, 0));
            gameObjects.Add(item);
        }
    }
}
