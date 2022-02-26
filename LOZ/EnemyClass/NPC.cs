using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;


namespace LOZ.EnemyClass
{
    class NPC : IEnemy
    {
        private Point position;
        private ISprite npc;

        public NPC(Point location)
        {
            position = location;
            npc = EnemySpriteFactory.Instance.CreateNPC();
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
