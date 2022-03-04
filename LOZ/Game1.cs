﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.ControllerClasses;
using LOZ.GameState;
using LOZ.DungeonClasses;
using LOZ.Collision;
using LOZ.MapIO;
using System.IO;
using System.Reflection;

namespace LOZ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        private List<IController> controllerList;

        private Dictionary<Point, List<IGameObjects>> maps;
        public List<Room> Rooms { get; set; } = new List<Room>();

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

            CurrentRoom.Instance.LoadTextures(Content);
            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetKeyboardController()},
                { new KeyBindings(this).GetMouseController()},
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

            maps = new Dictionary<Point, List<IGameObjects>>();
            //https://stackoverflow.com/questions/6246074/mono-c-sharp-get-application-path
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.remove?view=net-6.0
            string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            IO allMap = new IO(maps, filePath + "/Content/DugeonRooms");
            allMap.Parse();

            foreach (KeyValuePair<Point, List<IGameObjects>> room in maps)
            {
                Rooms.Add(new DungeonRoom(room.Value));
            }

            CurrentRoom.Instance.Rooms = Rooms;
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
