using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class TopSandWall : AbstractOverworld
    {
		public TopSandWall(Point location)
        {
			Position = location;
            sprite = OverworldFactory.Instance.TopWall();
        }
        public override Hitbox GetHitBox() => new Hitbox(Position.X - 24, Position.Y - 24, 48, 48);
    }
}
