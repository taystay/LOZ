using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LOZ.Factories;
using LOZ.LinkClasses;
using LOZ.ItemsClasses;
using LOZ.Collision;
using LOZ.EnemyClass;
using LOZ.EnvironmentalClasses;
using System;
namespace LOZ.GameState
{
    public class DungeonRoom : Room
    {
        public DungeonRoom(List<IGameObjects> list)
        {
            gameObjects = list;
        }

        public override void LoadContent() { }
    }
}
