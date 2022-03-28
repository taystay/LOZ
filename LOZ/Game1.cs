using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.ControllerClasses;
using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.MapIO;
using System.IO;
using System.Reflection;
using LOZ.Sound;
using LOZ.Hud;

namespace LOZ
{
    public enum CameraState
    {
        Paused,
        Playing,
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private List<IController> controllerList;
        private Dictionary<Point3D, Room> maps;

        public CameraState state { get; set; } = CameraState.Playing;
        private HudElement pausedHud;
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

            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetKeyboardController()},
                { new KeyBindings(this).GetMouseController()},
            };
            CurrentRoom.Instance.SpawnLink();

            pausedHud = new PauseHud(Room.RoomInventory, Content);
            base.LoadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }
            if (state == CameraState.Playing)
                CurrentRoom.Instance.Update(gameTime);
            else if (state == CameraState.Paused)
                pausedHud.Update();


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            if (state == CameraState.Playing)
                CurrentRoom.Instance.Draw(spriteBatch);
            else if (state == CameraState.Paused)
                pausedHud.Draw(spriteBatch);


            base.Draw(gameTime);
        }
    }
}
