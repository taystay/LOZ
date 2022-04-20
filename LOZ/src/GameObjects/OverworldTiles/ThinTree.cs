using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public class ThinTree : AbstractOverworld
    {
        private ISprite topleft;
        private ISprite bottomleft;
        private ISprite topright;
        private ISprite bottomright;
		public ThinTree(Point location)
        {
			Position = location;
            OverworldFactory fac = OverworldFactory.Instance;
            topleft = fac.TopLeftTree();
            bottomleft = fac.BottomLeftTree();
            topright = fac.TopRightTree();
            bottomright = fac.BottomRightTree();
        }
        public override Hitbox GetHitBox() => new Hitbox(Position.X - 48, Position.Y - 48, 96, 96);
        public override void Update(GameTime gameTime)
        {
            topleft.Update(gameTime);
            bottomleft.Update(gameTime);
            topright.Update(gameTime);
            bottomright.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            int bw = 24;
            topleft.Draw(spriteBatch, Position + new Point(-bw, -bw) + offset);
            bottomleft.Draw(spriteBatch, Position + new Point(-bw, bw) + offset);
            topright.Draw(spriteBatch, Position + new Point(bw, -bw) + offset);
            bottomright.Draw(spriteBatch, Position + new Point(bw, bw) + offset);
        }
    }
}
