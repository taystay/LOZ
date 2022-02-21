using Sprint2.SpriteClasses.EnemeySprite;
using Sprint2.Factories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2.EnemyClass
{
    class SpikeTrap : IEnemy
    {
        private ISprite trap;
        private Point position;
        public SpikeTrap(Point location) {
            trap = EnemySpriteFactory.Instance.CreateTrap();
            position = location;
        }

        public void Update(GameTime timer) {
            trap.Update(timer);
        }

        public void Draw(SpriteBatch spriteBatch) {
            trap.Draw(spriteBatch, position);
        }

    }
}
