using LOZ.MapIO;
using LOZ.Collision;
using System.Collections.Generic;
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
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            GameFont.Instance.Write(spriteBatch, "Some walls may be bombable", 265 + offset.X, 450 + offset.Y);
            foreach (IGameObjects item in gameObjects)
            {
                item.Draw(spriteBatch, offset);
            }
            CurrentRoom.link.Draw(spriteBatch, offset);

            if (!CurrentRoom.DebugMode) return;
            foreach (IGameObjects item in gameObjects)
            {
                item.GetHitBox().Draw(spriteBatch, offset);
            }
            CurrentRoom.link.GetHitBox().Draw(spriteBatch, offset);
        }
    }
}
