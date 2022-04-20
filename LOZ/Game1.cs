using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.DungeonClasses;
using System.IO;
using System.Reflection;
using LOZ.Sound;
using LOZ.Factories;
using LOZ.src.CameraStates;
using LOZ.Room;
using LOZ.Hud;
using LOZ.GameStateReference;

namespace LOZ
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public ICameraState CameraState { get; set; }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
          
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Info.screenWidth;
            graphics.PreferredBackBufferHeight = Info.screenHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            OverworldFactory.Instance.LoadAllTextures(Content);
            DisplaySpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            DungeonFactory.Instance.LoadAllTextures(Content);
            GameFont.Instance.LoadAllTextures(Content);
            GetReference.SetReference(this);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);        
            
            SoundManager.Instance.LoadSound(Content);

            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            RoomMaker roomMaker = new RoomMaker(filePath + "/Content/DugeonRooms/DugeonRooms/");
            Dictionary<Point3D, IRoom> allRooms = roomMaker.CreateAllRooms();

            CurrentRoom.Instance.LoadContents(allRooms);

            bool debugState = true;
            if(debugState)
            {
                HudElement inv = new InventoryHud(RoomReference.GetLink().Inventory);
                inv.Offset(new Point(0, -630));
                CameraState = new FirstDungeon(this, inv);
            } else
                CameraState = new MainMenuState(this);

            base.LoadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            CameraState.UpdateController(gameTime);
            CameraState.Update(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);



            // this rendertarget will hold a black rectangle that gets masked with alphaMask
            RenderTarget2D darkness = new RenderTarget2D(GraphicsDevice, Info.screenWidth, Info.screenHeight);

            // the stuff we mask out of darkness, essentially this texture defines our lights
            Texture2D alphaMask = Content.Load<Texture2D>("whiteCircle");

            // prepare the darkness
            GraphicsDevice.SetRenderTarget(darkness);
            GraphicsDevice.Clear(new Color(0, 0, 0, 100));

            var blend = new BlendState
            {
                AlphaBlendFunction = BlendFunction.ReverseSubtract,
                AlphaSourceBlend = Blend.One,
                AlphaDestinationBlend = Blend.One,
            };

            spriteBatch.Begin(blendState: blend);
            spriteBatch.Draw(alphaMask, darkness.Bounds, Color.White);
            spriteBatch.End();

            // set the render target back to the backbuffer
            GraphicsDevice.SetRenderTarget(null);
            // Clear it
            GraphicsDevice.Clear(Color.Black);


            CameraState.Draw(spriteBatch);
            if (RoomReference.GetDebug())
                GameFont.Instance.Write(spriteBatch, "CameraState: " + CameraState.GetType().ToString(), 75, 910);
            spriteBatch.Begin();
            // draw the masked darkness!
            spriteBatch.Draw(darkness, Vector2.Zero, Color.White);
            spriteBatch.End();










            ////https://community.monogame.net/t/how-to-make-lightsources-torch-fire-campfire-etc-in-dark-area-2d-pixel-game/8058/20

            base.Draw(gameTime);
        }
    }
}
