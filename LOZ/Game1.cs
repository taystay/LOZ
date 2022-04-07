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

namespace LOZ
{
    public enum CameraState
    {
        MainMenu,
        Paused,
        Pausing,
        Unpausing,
        Playing,
        Victory
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private List<IController> controllerList;
        private Dictionary<Point3D, Room> maps;
        private SpriteFont font;
        private ISprite GameOverDisplay, EndScreenAnimation;
        private Texture2D fade;
        private float alpha = 0.0f;
        private ISprite menuTest;

        public CameraState state { get; set; } = CameraState.MainMenu;
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

            GameOverDisplay = DisplaySpriteFactory.Instance.CreateDeadDisplay();

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

            font = Content.Load<SpriteFont>("File");
            fade = Content.Load<Texture2D>("Black");
            EndScreenAnimation = DisplaySpriteFactory.Instance.CreateEndScreen();
            menuTest = DisplaySpriteFactory.Instance.GetMainMenu();
            base.LoadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            
            foreach (IController controller in controllerList)
            {
                if(!CurrentRoom.Instance.transition)
                    controller.Update(gameTime);
            }
            if (Room.RoomInventory.hasTriforce)
                EndScreenAnimation.Update(gameTime);
            else if (state == CameraState.Playing)
                CurrentRoom.Instance.Update(gameTime);
            else if (state == CameraState.Paused)
                pausedHud.Update();
            else if (state == CameraState.MainMenu)
            {
                menuTest.Update(gameTime);
                if (Keyboard.GetState().GetPressedKeyCount() > 0)
                    state = CameraState.Playing;
            }

            //BUG: I had friend play it all the enmies stopped updating but link was being updated.
            //he could move so room was not in transition state, he didnt have triforce and the pause hud wasnt being drawn. Thus
            // he has to be in playing state or one of the pasuing / unpasuing states. so if anyone figures out this bug lmk.


            base.Update(gameTime);
        }
        private void DrawFade(SpriteBatch spriteBatch)
        {
            alpha += 0.07f;
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
            spriteBatch.Draw(fade, new Rectangle(0, 0, Info.screenWidth, Info.screenHeight), Color.White * alpha);
            spriteBatch.End();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            if(Room.RoomInventory.hasTriforce)
            {
                CurrentRoom.Instance.Draw(spriteBatch);
                EndScreenAnimation.Draw(spriteBatch, new Point());
                Room.Link.Draw(spriteBatch);
                
            }
            else if (state == CameraState.Playing)
            {
                CurrentRoom.Instance.Draw(spriteBatch);
                if (Room.Link.Health <= 0)
                    GameOverDisplay.Draw(spriteBatch, new Point(500, 500));
            } 
            else if(state == CameraState.Pausing)
            {
                CurrentRoom.Instance.Draw(spriteBatch);
                DrawFade(spriteBatch);
                if (alpha > 1.00f)
                {
                    alpha = 0.0f;
                    state = CameraState.Paused;
                }         
            }
            else if (state == CameraState.Unpausing)
            {
                pausedHud.Draw(spriteBatch);
                DrawFade(spriteBatch);
                if (alpha > 1.00f)
                {
                    alpha = 0.0f;
                    state = CameraState.Playing;
                }               
            }
            else if (state == CameraState.Paused)
            {
                pausedHud.Draw(spriteBatch);
            } else if (state == CameraState.MainMenu)
            {
                menuTest.Draw(spriteBatch, new Point(Info.screenWidth / 2, Info.screenHeight / 2));
            }
                

            if (!Room.DebugMode) return;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "" + Mouse.GetState().X + "," + Mouse.GetState().Y + ", state: " + state.ToString(), new Vector2(50, 50), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
