using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class IterableBlock : IIterable
    {
        private static List<IEnvironment> blocks;
        private Point blockLocation = new Point(700, 300);
        private static int blockIndex = 0;
        private double scale = 1.0;

        public IterableBlock()
        {
            
            blocks = new List<IEnvironment>()
            {
                { new BlueSandBlock(blockLocation, scale) },
                { new BlackTileBlock(blockLocation, scale) },
                { new BlueTriangleBlock(blockLocation, scale) },
                { new DarkBlueBlock(blockLocation, scale) },
                { new MulticoloredBlock1(blockLocation, scale) },
                { new MulticoloredBlock2(blockLocation, scale) },
                { new SolidBlueBlock(blockLocation, scale) },
                { new StairsBlock(blockLocation, scale) },
            }; 
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
