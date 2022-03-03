using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LOZ.LinkClasses;
using LOZ.Collision;
using LOZ.EnvironmentalClasses;
using LOZ.MapIO;
using LOZ.DungeonClasses;
using LOZ.SpriteClasses.BlockSprites;
namespace LOZ.GameState
{
    public class EmptyRoom : Room
    {
        public EmptyRoom()
        {
            
        }

        public override void LoadContent()
        {
            gameObjects = new List<IGameObjects>();
            colliders = new CollisionIterator(gameObjects);
            Link = new Link(new Point(1000, 500));
            gameObjects.Add(Link);
            //gameObjects.Add(new ExteriorObject());
            //gameObjects.Add(StringToBlock.Convert("BlackTileBlock", 200, 500));
            gameObjects.Add(new InvisibleBlock(new Point(300, 500)));
        }
    }
}
