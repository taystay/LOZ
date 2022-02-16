using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.EnemyClass;
using Sprint2.EnemyClass.Projectiles;


namespace Sprint2.GameState
{
    class IterableEnemy : IIterable
    {
        private List<IProjectile> projectiles;
        private static List<IEnemy> enemies;
        private static int enemyIndex = 0;
        public IterableEnemy()
        {
            LoadList();
        }

        private void LoadList()
        {
            projectiles = new List<IProjectile>();
            enemies = new List<IEnemy>()
            {
                {new Dragon(new Point(700, 700), projectiles,2)},
                {new Skeleton(new Point(700, 700),1) },
                {new Bat(new Point(700, 700),1) },
                {new Jelly(new Point(700, 700),1) },
                {new NPC(new Point(700,700),2)},
            };
        }
        public void SetToDefault()
        {
            enemyIndex = 0;
            LoadList();
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
