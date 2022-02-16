using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.EnvironmentalClasses;

namespace Sprint2.GameState
{
    class IterableBlock : IIterable
    {
        private static List<IEnvironment> blocks;
        private Point blockLocation = new Point(700, 300);
        private static int blockIndex = 0;

        public IterableBlock()
        {
            LoadList();
             
        }

        private void LoadList()
        {
            blocks = new List<IEnvironment>()
            {
                { new BlueSandBlock(blockLocation) },
                { new BlackTileBlock(blockLocation) },
                { new BlueTriangleBlock(blockLocation) },
                { new DarkBlueBlock(blockLocation) },
                { new MulticoloredBlock1(blockLocation) },
                { new MulticoloredBlock2(blockLocation) },
                { new SolidBlueBlock(blockLocation) },
                { new StairsBlock(blockLocation) },
            };
        }
        public void SetToDefault()
        {
            blockIndex = 0;
            LoadList();
        }

        public void IterateForward()
        {
            blockIndex++;
            if (blockIndex >= blocks.Count)
                blockIndex = 0;  

        }
        public void IterateReverse()
        {
            blockIndex--;
            if (blockIndex < 0)
                blockIndex = blocks.Count - 1;
        }
        public void Update(GameTime gameTime)
        {
            blocks[blockIndex].Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            blocks[blockIndex].Draw(spriteBatch);
        }

    }
}
