using LOZ.MapIO;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;

namespace LOZ.Room
{
    class Room13 : RoomAbstract
    {
        //private List<IGameObjects> roomObj;
        public Room13(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "1_3.csv");
            gameObjects.Add(new NPC(GetCoorPoint(6, 3)));
            gameObjects.Add(new FireItem(GetCoorPoint(4, 3)));
            gameObjects.Add(new FireItem(GetCoorPoint(8, 3)));
            colliders = new CollisionIterator(gameObjects);
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            GameFont.Instance.Write(spriteBatch, "Some walls may be bombable", 265 + offset.X, 450 + offset.Y);
            DrawNor
        }
    }
}
