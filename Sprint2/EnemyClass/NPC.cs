using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class NPC : IEnemy
    {
        private Point position;
        private ISprite npc;

        public NPC(Point location, double size)
        {
            position = location;
            npc = EnemySpriteFactory.Instance.CreateNPC();
            npc.SetSize(size);
        }

        public void Update(GameTime timer)
        {
            npc.Update(timer);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            npc.Draw(spriteBatch, position);
        }

    }
}
