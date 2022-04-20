using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Factories;
using LOZ.SpriteClasses;
using LOZ.Collision;
using System.Collections.Generic;
using System.Linq;

namespace LOZ.EnvironmentalClasses
{
    public class StumpDoor : AbstractOverworld
    {
        private Dictionary<ISprite, Point> stumpSprites;
        private ISprite blackBox;
		public StumpDoor(Point location)
        {
			Position = location;
            OverworldFactory fac = OverworldFactory.Instance;
            stumpSprites = new Dictionary<ISprite, Point>();
            stumpSprites.Add(fac.BottomLeftTree(), new Point(-48, 24));
            stumpSprites.Add(fac.TopLeftTree(), new Point(-48, -24));
            stumpSprites.Add(fac.BottomRightTree(), new Point(48, 24));
            stumpSprites.Add(fac.TopRightTree(), new Point(48, -24));
            stumpSprites.Add(fac.CenterTree(), new Point(0, -24));
            blackBox = DisplaySpriteFactory.Instance.GetMapWalk(48,48);
        }
        public override Hitbox GetHitBox() => new Hitbox(Position.X - 144/2, Position.Y - 96/2, 144, 96);
        public override void Update(GameTime gameTime)
        {
            foreach(ISprite s in stumpSprites.Keys.ToList<ISprite>())
            {
                s.Update(gameTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch, Point offset)
        {
            foreach (KeyValuePair<ISprite, Point> pair in stumpSprites)
            {
                pair.Key.Draw(spriteBatch, Position + offset + pair.Value);
            }
            blackBox.Draw(spriteBatch, Position + offset + new Point(0, 24), Color.Black);
        }
    }
}
