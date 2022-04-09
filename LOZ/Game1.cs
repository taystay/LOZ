using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.ControllerClasses;
using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.MapIO;
using System.IO;
using System.Reflection;
using LOZ.Sound;
using LOZ.Hud;
using LOZ.SpriteClasses;
using LOZ.SpriteClasses.DisplaySprites;
using LOZ.Factories;
using LOZ.src.CameraStates;

namespace LOZ
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Dictionary<Point3D, Room> maps;
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

            DisplaySpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            DungeonFactory.Instance.LoadAllTextures(Content);
            GameFont.Instance.LoadAllTextures(Content);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);        
            
            SoundManager.Instance.LoadSound(Content);
            CurrentRoom.Instance.LoadTextures(Content);
            maps = new Dictionary<Point3D, Room>();
            //https://stackoverflow.com/questions/6246074/mono-c-sharp-get-application-path
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.remove?view=net-6.0
            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            IO allMap = new IO(maps, filePath + "/Content/DugeonRooms");
            allMap.Parse();
            CurrentRoom.Instance.Rooms = maps;
            CurrentRoom.Instance.SpawnLink();      

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

            if (Room.DebugMode)
                GameFont.Instance.Write(spriteBatch, "" + Mouse.GetState().X + "," + Mouse.GetState().Y, 50, 50);

            base.Draw(gameTime);
        }
    }
}
