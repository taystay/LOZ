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
        public SpriteBatch spriteBatch { get; set; }
        public ICameraState CameraState { get; set; }
        public bool HardCore { get; set; }
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
            FOWFactory.Instance.PrepareShadow(spriteBatch, GraphicsDevice);


            SoundManager.Instance.LoadSound(Content);

            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            RoomMaker roomMaker = new RoomMaker(filePath + "/Content/DugeonRooms/DugeonRooms/");
            Dictionary<Point3D, IRoom> allRooms = roomMaker.CreateAllRooms();

            CurrentRoom.Instance.LoadContents(allRooms);

            bool debugState = false;
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
      
            CameraState.Draw(spriteBatch);
            if (RoomReference.GetDebug())
                GameFont.Instance.Write(spriteBatch, "CameraState: " + CameraState.GetType().ToString(), 75, 910);

            base.Draw(gameTime);
        }
    }
}
