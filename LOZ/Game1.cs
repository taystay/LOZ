using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.ControllerClasses;
using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.MapIO;
using LOZ.Collision;

namespace LOZ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<IController> controllerList;
        private Dictionary<Point, List<IGameObjects>> maps;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // https://community.monogame.net/t/get-the-actual-screen-width-and-height-on-windows-10-c-monogame/10006
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            maps = new Dictionary<Point, List<IGameObjects>>();

            CurrentRoom.Instance.LoadTextures(Content);
            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetController()},
            };         
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            int x = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - DungeonInfo.DungeonWidth / 2;
            int y = 400;
            DungeonInfo.Map = new Rectangle(x, y, 3 * (776 - 521 + 1), 3 * (186 - 11 + 1));
            DungeonInfo.Inside = new Rectangle(x + 32 * 3, y + 32 * 3, 576, 336);
            CurrentRoom.Room = new DevRoom();
            CurrentRoom.Room.LoadContent();
            //IO allMap = new IO(maps, "");
            //allMap.Parse();

        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }
            CurrentRoom.Room.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            CurrentRoom.Room.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
