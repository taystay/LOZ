using LOZ.MapIO;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using LOZ.EnemyClass;
using LOZ.ItemsClasses;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.DungeonClasses;

namespace LOZ.Room
{
    class Room13 : RoomAbstract
    {
        public Room13(string pathFile)
        {
            gameObjects = IO.Instance.ParseRoom(pathFile + "1_3.csv");
            gameObjects.Add(new NPC(GetCoorPoint(5.5, 3)));
            gameObjects.Add(new FireItem(GetCoorPoint(3, 3)));
            gameObjects.Add(new FireItem(GetCoorPoint(8, 3)));
            exterior = new ExteriorObject(DoorType.Wall, DoorType.Door, DoorType.Wall, DoorType.Wall, gameObjects);
            colliders = new CollisionIterator(gameObjects);
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            DrawNormally(spriteBatch, offset);
            GameFont.Instance.Write(spriteBatch, "    Some walls may\n      be bombable", 265 + offset.X + 50, 450 + offset.Y + 24);         
        }
    }
}
