using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;


namespace LOZ.EnemyClass
{
    class NPC : AbstractEnemy
    {

        public NPC(Point location)
        {
            position = location;
            _texture = EnemySpriteFactory.Instance.CreateNPC();
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(position.X - 17 / 2, position.Y - 5, 14, 16);
        }

        public override void Update(GameTime timer)
        {
            _texture.Update(timer);
        }

    }
}
