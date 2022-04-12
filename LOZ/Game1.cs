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
        //private Dictionary<Point3D, OldRoom> maps;
        public ICameraState CameraState { get; set; }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
          
        }
        protected override void Initialize()
        {
            // https://community.monogame.net/t/get-the-actual-screen-width-and-height-on-windows-10-c-monogame/10006
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
            //CurrentRoom.Instance.LoadTextures(Content);
           
            //https://stackoverflow.com/questions/6246074/mono-c-sharp-get-application-path
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.remove?view=net-6.0
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
            if(RoomReference.GetDebug())
               GameFont.Instance.Write(spriteBatch, "CameraState: " + CameraState.GetType().ToString(), 75, 910);
            //else
            //{
            //    Factories.GameFont.Instance.Write(spriteBatch, "TotalMS: " + gameTime.TotalGameTime.TotalMilliseconds, 300, 200);
            //    Factories.GameFont.Instance.Write(spriteBatch, "mod 1000: " + ((int)gameTime.TotalGameTime.TotalMilliseconds % 1000 == 0), 300, 250);
            //}

            base.Draw(gameTime);
        }
    }
}
