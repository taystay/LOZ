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


        //-----Current Objects On Screen-----
        private List<IItem> Items;
        public ISprite Sprite;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //--------------Initialize variables for screen drawing---------------------------
            ScreenDim = new Point(GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
            Start = new Point(ScreenDim.X / 2, ScreenDim.Y / 2); 
            Position = new Point(Start.X, Start.Y);

            //----------------------Initialize Controllers----------------------
            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetController()},
            };

            Items = new List<IItem>();

            //----------------Initialize Screen Data-------------------------
            _graphics.PreferredBackBufferWidth = ScreenDim.X;
            _graphics.PreferredBackBufferHeight = ScreenDim.Y;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        public void HiICreateTonysSpritesTest()
        {
            double HiIAmAVariable = 2.0;
            Items.Add(new Compass(new Point(500, 500), HiIAmAVariable));
            Items.Add(new Clock(new Point(400, 500), HiIAmAVariable));
            Items.Add(new ArrowItem(new Point(300, 500), HiIAmAVariable));
            Items.Add(new FireItem(new Point(200, 500), HiIAmAVariable));
            Items.Add(new Map(new Point(600, 500), HiIAmAVariable));
            Items.Add(new Key(new Point(700, 500), HiIAmAVariable));
            Items.Add(new HeartContainer(new Point(200, 600), HiIAmAVariable));
            Items.Add(new Triforce(new Point(300, 600), HiIAmAVariable));
            Items.Add(new Bow(new Point(400, 600), HiIAmAVariable));
            Items.Add(new Heart(new Point(500, 600), HiIAmAVariable));
            Items.Add(new Rupee(new Point(600, 600), HiIAmAVariable));
            Items.Add(new Bomb(new Point(700, 600), HiIAmAVariable));
            Items.Add(new Fairy(new Point(200, 700), HiIAmAVariable));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //---Give All Objects a starting position
            ItemFactory.Instance.LoadAllTextures(Content);
            HiICreateTonysSpritesTest();
        }
        protected override void Update(GameTime gameTime)
        {
            //-------------------------------------------------------
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            List<int> IndicesToRemove = new List<int>();
            foreach (IItem item in Items)
            {
                item.Update(gameTime);
                if (!item.SpriteActive())
                {
                    IndicesToRemove.Add(Items.IndexOf(item));
                }
            }
            foreach(int i in IndicesToRemove)
            {
                Items.RemoveAt(i);
            }
            

            //--------------------------------------------------
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            foreach(IItem item in Items)
            {
                item.Draw(_spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
