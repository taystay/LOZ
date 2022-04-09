using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Collision;
using System.Collections.Generic;
using LOZ.EnemyClass;
using LOZ.LinkClasses;

namespace LOZ
{
    //abstract class RoomAbstract : IRoom
    //{
    //    private protected List<IGameObjects> gameObjects;
    //    private protected bool HasEnemies = false;
    //    public static ILink Link { get; set; }
    //    private protected List<IGameObjects> RemovedInDetection { get; set; } = new List<IGameObjects>();
    //    public static bool DebugMode {get;set;}

    //    public virtual void Update(GameTime gameTime) {

    //        HasEnemies = false;
    //        for (int i = 0; i < gameObjects.Count; i++)
    //        {            
    //            IGameObjects item = gameObjects[i];
    //            if (TypeC.Check(item, typeof(IEnemy)))
    //                HasEnemies = true;
    //            item.Update(gameTime);
    //        }

    //        Link.Update(gameTime);

    //    }

    //    public virtual void Draw(SpriteBatch spriteBatch) {
    //        foreach (IGameObjects item in gameObjects)
    //        {
    //            item.Draw(spriteBatch);
    //        }

    //        Link.Draw(spriteBatch);

    //        if (!DebugMode) return; //Debug hitboxes for easy of testing numbers
    //        foreach (IGameObjects item in gameObjects)
    //        {
    //            item.GetHitBox().Draw(spriteBatch);
    //        }
    //        Link.GetHitBox().Draw(spriteBatch);

    //    }

    //    public virtual void RemoveItems() {

    //        foreach (IGameObjects item in RemovedInDetection)
    //        {
    //            gameObjects.Remove(item);
    //        }

    //    }
    //}
}
