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
        public ICameraState stateOfGame { get; set; }

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

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);        
            CurrentRoom.Instance.LoadTextures(Content);
            SoundManager.Instance.LoadSound(Content);

            maps = new Dictionary<Point3D, Room>();
            //https://stackoverflow.com/questions/6246074/mono-c-sharp-get-application-path
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.remove?view=net-6.0
            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            IO allMap = new IO(maps, filePath + "/Content/DugeonRooms");
            allMap.Parse();

            CurrentRoom.Instance.Rooms = maps;

            CurrentRoom.Instance.SpawnLink();      

            stateOfGame = new MainMenuState(this);

            base.LoadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            stateOfGame.UpdateController(gameTime);
            stateOfGame.Update(gameTime);

            //BUG: I had friend play it all the enmies stopped updating but link was being updated.
            //he could move so room was not in transition state, he didnt have triforce and the pause hud wasnt being drawn. Thus
            // he has to be in playing state or one of the pasuing / unpasuing states. so if anyone figures out this bug lmk.


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            stateOfGame.Draw(spriteBatch);


            if (Room.DebugMode)
                GameFont.Instance.Write(spriteBatch, "" + Mouse.GetState().X + "," + Mouse.GetState().Y, 50, 50);

            base.Draw(gameTime);
        }
    }
}
