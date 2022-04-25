using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.DungeonClasses;
using Microsoft.Xna.Framework;
using LOZ.GameStateReference;

namespace LOZ.Factories
{
    class FOWFactory
    {
		private Texture2D alphaMask;
        private RenderTarget2D darkness;
		private static FOWFactory instance = new FOWFactory();
		public static FOWFactory Instance { get => instance; }
		private FOWFactory() { }
		public void LoadAllTextures(ContentManager content) =>
			alphaMask = content.Load<Texture2D>("whiteCircle");

		public void PrepareShadow(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
		{
            darkness = new RenderTarget2D(graphicsDevice, Info.screenWidth * 3, Info.screenHeight * 3);
            alphaMask = DisplaySpriteFactory.Instance.GetAlphaMask();
            graphicsDevice.SetRenderTarget(darkness);
            graphicsDevice.Clear(new Color(0, 0, 0, 0));
            var blend = new BlendState
            {
                AlphaBlendFunction = BlendFunction.Subtract,
            };
            spriteBatch.Begin(blendState: blend);
            spriteBatch.Draw(alphaMask, darkness.Bounds, Color.Black);
            spriteBatch.End();
            graphicsDevice.SetRenderTarget(null);
            graphicsDevice.Clear(Color.Black);
        }

        public void DrawShadow(SpriteBatch spriteBatch) =>
            DrawShadow(spriteBatch, new Point());

        public void DrawShadow(SpriteBatch spriteBatch, Point offset)
        {
            Vector2 drawPoint = RoomReference.GetLink().Position.ToVector2() - new Vector2(darkness.Width / 2, darkness.Height / 2) + offset.ToVector2();
            spriteBatch.Begin();
            spriteBatch.Draw(darkness, drawPoint, Color.White);
            spriteBatch.End();
        }
    }
}
