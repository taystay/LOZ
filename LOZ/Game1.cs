﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprint2.GameState;
using Sprint2.ControllerClasses;
using LOZ.GameState;

namespace Sprint2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Room currentRoom;

        private List<IController> controllerList;
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

            currentRoom = new TestingRoom();
            
            //GameObjects.Instance.LoadObjects(Content);
            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetController()},
            };
            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            currentRoom.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);         
            

        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }
            //GameObjects.Instance.UpdateObjects(gameTime); 
            currentRoom.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            //GameObjects.Instance.DrawObjects(spriteBatch);
            currentRoom.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
