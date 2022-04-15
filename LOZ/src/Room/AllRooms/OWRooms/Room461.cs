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
        private AbstractEnemy skeletron;
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
            fullHeart.ChangeScale(0.3);
            halfHeart.ChangeScale(0.3);
        }

        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            DrawNormally(spriteBatch, offset);
            int skeletronHealth = skeletron.Health;
            Point start = skeletron.Position + new Point(-12 * (skeletronHealth / 4 - 1),-45);
            for (int i = 0; i < skeletronHealth / 2; i++)
            {
                fullHeart.Draw(spriteBatch, start + offset);
                start.X += 12;
            }
        }
    }
}
