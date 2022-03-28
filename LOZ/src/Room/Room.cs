﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.LinkClasses;
using LOZ.EnemyClass;
using LOZ.EnemyClass.Projectiles;
using LOZ.Hud;
using LOZ.Inventory;
using LOZ.DungeonClasses;

namespace LOZ.GameState
{
    public abstract class Room
    {

        public static HudElement hudele { get; set; }
        public static LinkInventory RoomInventory { get; set;}

        public List<IGameObjects> GameObjects { get; set; }
        public ExteriorObject exterior { get; set; }
        private protected CollisionIterator colliders;

        public static ILink Link { get; set; } // only one link so we dont accidently break the game with the decorator.
        public static bool DebugMode { get; set; } = false;
        public bool Damaged { get; set; } = false;
        
        public abstract void LoadContent();       
        public void Update(GameTime gameTime)
        {
            if(exterior != null) exterior.Update(gameTime);
            Link.Update(gameTime);
            for (int i = 0; i < GameObjects.Count; i++)
            { // for loop because state of list may change. (items added)
                IGameObjects item = GameObjects[i];
                item.Update(gameTime);
            }    

            RemoveDeadItems();
            colliders.Iterate();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (exterior != null) exterior.Draw(spriteBatch);
            hudele.Draw(spriteBatch);
            foreach (IGameObjects item in GameObjects)
            {
                item.Draw(spriteBatch);
            }
            Link.Draw(spriteBatch);

            if (!DebugMode) return; //Debug hitboxes for easy of testing numbers
            foreach (IGameObjects item in GameObjects)
            {
                item.GetHitBox().Draw(spriteBatch);
            }
            Link.GetHitBox().Draw(spriteBatch);
        }
        private void RemoveDeadItems()
        {
            for(int i = GameObjects.Count - 1; i >= 0; i--)
            {
                IGameObjects item = GameObjects[i];
                if (TypeC.Check(item, typeof(IItem)))
                { //allow us to take items out of the game without them doing it themselves.
                    IItem itemObject = (IItem)item;
                    if (!itemObject.SpriteActive()) GameObjects.RemoveAt(i);
                }
                if (TypeC.Check(item, typeof(AbstractEnemy)))
                {
                    AbstractEnemy itemObject = (AbstractEnemy)item;
                    if (!itemObject.IsActive()) GameObjects.RemoveAt(i);
                }
                if (TypeC.Check(item, typeof(DragonBreathe)))
                {
                    DragonBreathe itemObject = (DragonBreathe)item;
                    if (!itemObject.IsActive()) GameObjects.RemoveAt(i);
                }
            }
        }
    }
}
