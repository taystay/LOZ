using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;  

namespace Sprint2
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //-----Public Variables for logic-----
        private Point ScreenDim;
        private Point Position;
        private Point Start;

        private List<IController> controllerList;
        private Texture2D texture;
        public ISprite Sprite;
        private ISprite Font;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        public Point GetDim()
        {
            return ScreenDim;
        }
        public Texture2D GetTexture()
        {
            return texture;  
        }
        public Point GetStartingPosition()
        {
            return Start;
        }

        protected override void Initialize()
        {
            //--------------Initialize variables for screen drawing---------------------------
            ScreenDim = new Point(GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
            Start = new Point(ScreenDim.X / 2, ScreenDim.Y / 2); 
            Position = new Point(Start.X, Start.Y);

            //-----------------Initialize Sprites----------------------------
            texture = Content.Load<Texture2D>("megaman");
            Sprite = new IdleSprite(texture);

            //----------------------Initialize Controllers----------------------
            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetController()},
                { new MouseClickLocations(this).GetController() }
            };

            //----------------Initialize Screen Data-------------------------
            _graphics.PreferredBackBufferWidth = ScreenDim.X;
            _graphics.PreferredBackBufferHeight = ScreenDim.Y;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Font = new FontSprite(Content.Load<SpriteFont>("Bubble"), "Anthony D'Alesandro\nSprite Sheet: https://www.spriters-resource.com/nes/mm/ \nhttps://www.dafont.com/");
        }
        protected override void Update(GameTime gameTime)
        {
            //-------------------------------------------------------
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            Sprite.Update();

            //--------------------------------------------------
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Sprite.Draw(_spriteBatch, Position);
            //Font.Draw(_spriteBatch,new Point(0, ScreenDim.Y * 3 / 4));
            base.Draw(gameTime);
        }
    }
}
