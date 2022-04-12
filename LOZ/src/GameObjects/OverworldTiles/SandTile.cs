using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class SandTile : AbstractOverworld
    {
		public SandTile(Point location)
        {
			Position = location;
            sprite = OverworldFactory.Instance.Sand();
        }
        public override Hitbox GetHitBox() => new Hitbox(0, 0, 0, 0);
    }
}
