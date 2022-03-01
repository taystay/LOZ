using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;


namespace LOZ.EnemyClass
{
    class NPC : AbstractEnemy
    {

        public NPC(Point location)
        {
            Position = location;
            _texture = EnemySpriteFactory.Instance.CreateNPC();
        }

        public override Hitbox GetHitBox()
        {
            return new Hitbox(-50 ,-50,0,0);
        }

        public override void Update(GameTime timer)
        {
            _texture.Update(timer);
        }

    }
}
