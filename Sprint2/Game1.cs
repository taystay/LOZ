using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;  

namespace Sprint2
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private IEnemy enemy;

        //-----Public Variables for logic-----
        private Point screenDim;
        private Point position;
        private Point start;

        private List<IController> controllerList;


        //-----Current Objects On Screen-----
        private List<IItem> Items;
        public ISprite Sprite;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //--------------Initialize variables for screen drawing---------------------------
            screenDim = new Point(GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
            start = new Point(screenDim.X / 2, screenDim.Y / 2); 
            position = new Point(start.X, start.Y);

            //----------------------Initialize Controllers----------------------
            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetController()},
            };

            Items = new List<IItem>();

            //----------------Initialize Screen Data-------------------------
           /* graphics.PreferredBackBufferWidth = screenDim.X;
            graphics.PreferredBackBufferHeight = screenDim.Y;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();*/
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //---Give All Objects a starting position
            ItemFactory.Instance.LoadAllTextures(Content);

            HiICreateTonysSpritesTest();

            /* EnemySpriteFactory.Instance.LoadAllTextures(Content);
             enemy = new Jelly(new Point(100, 100));*/
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
            foreach (int i in IndicesToRemove)
            {
                Items.RemoveAt(i);
            }


            //--------------------------------------------------

            // enemy.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            /* enemy.Draw(spriteBatch);*/
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
