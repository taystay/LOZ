using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.DungeonClasses;

namespace LOZ.SpriteClasses
{
    class FadeOutSprite : ISprite
    {
		private double scale;
		private Rectangle frame;
		private Texture2D fade;
		private float alpha = 0.0f;
		private float dalpha = 0.05f;
		private bool isFading = true;
		public FadeOutSprite()
		{
			fade = Factories.DisplaySpriteFactory.Instance.getBlackFade();
		}
		public FadeOutSprite(float newDAlpha)
		{
			dalpha = newDAlpha;
			fade = Factories.DisplaySpriteFactory.Instance.getBlackFade();
		}

		public void Update(GameTime timer)
        {
			alpha += dalpha;
			if (alpha > 1.0f)
				isFading = false;
        }

		public bool FadeDone()
        {
			return !isFading;
        }

		public void Draw(SpriteBatch spriteBatch, Point location) {
			Draw(spriteBatch, location, Color.White);
		}

		public void ChangeScale(double scale)
        {

        }

		public void Draw(SpriteBatch spriteBatch, Point location, Color c)
		{
			//fade1.Draw(spriteBatch, location, c * alpha);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			spriteBatch.Draw(fade, new Rectangle(0, 0, Info.screenWidth, Info.screenHeight), Color.White * alpha);
			spriteBatch.End();
		}

	}
}
