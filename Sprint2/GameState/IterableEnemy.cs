﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class IterableEnemy : IIterable
    {
        private List<IProjectile> projectiles;
        private static List<IEnemy> enemies;
        private static int enemyIndex = 0;
        public IterableEnemy()
        {
            projectiles = new List<IProjectile>();
            enemies = new List<IEnemy>()
            {
                {new Dragon(new Point(700, 700), projectiles)},
                {new Skeleton(new Point(700, 700)) },
                {new Bat(new Point(700, 700)) },
                {new Jelly(new Point(700, 700)) },
                {new NPC(new Point(700,700))},
            };
            
        }

        public void IterateForward()
        {
            enemyIndex++;
            if (enemyIndex >= enemies.Count)
                enemyIndex = 0;
            

        }
        public void IterateReverse()
        {
            enemyIndex--;
            if (enemyIndex < 0)
                enemyIndex = enemies.Count - 1;
        }
        public void Update(GameTime gameTime)
        {
            enemies[enemyIndex].Update(gameTime);

            int i = 0;            
            while (i < projectiles.Count)
            {
                IProjectile item = projectiles[i];
                item.Update(gameTime);
                if (!item.IsActive())
                {
                    projectiles.RemoveAt(i);
                    continue;
                }
                i++;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            enemies[enemyIndex].Draw(spriteBatch);
            foreach (IProjectile item in projectiles)
            {
                item.Draw(spriteBatch);
            }
        }

    }
}
