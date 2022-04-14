using LOZ.MapIO;
using LOZ.Collision;
using LOZ.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.LinkClasses;
using LOZ.CommandClasses;
using LOZ.EnemyClass;
using LOZ.SpriteClasses;
using LOZ.Factories;

namespace LOZ.Room
{
    class Room461 : RoomAbstract
    {
        private ISprite fullHeart, halfHeart;
        private IEnemy skeletron;
        public Room461(string pathFile)
        {
            posX = GetCoorPoint(0, 3);
            gameObjects = IO.Instance.ParseOW(pathFile + "OWTileMaps.csv",13,25);
            gameObjects.Add(new DoorCollider(new Rectangle(GetCoorPoint(-2, 2.5), new Point(48,48)), new RoomnX(GetReference.GetRef()), typeof(ILink)));
            skeletron = new Skeletron(GetCoorPoint(10, 2), gameObjects);
            gameObjects.Add(skeletron);
            colliders = new CollisionIterator(gameObjects);
            fullHeart = DisplaySpriteFactory.Instance.GetHudHeart(true);
            halfHeart = DisplaySpriteFactory.Instance.GetHudHeart(false);
        }

        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            DrawNormally(spriteBatch, offset);
            int skeletronHealth = skeletron.Health;
            Point start = new Point(125, 250);
            for (int i = 0; i < skeletronHealth / 2; i++)
            {
                fullHeart.Draw(spriteBatch, start);
                start.X += 50;
            }
        }
    }
}
