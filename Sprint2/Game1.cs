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
        private ILink link;

        //-----Public Variables for logic-----
        private Point screenDim;
        private Point position;
        private Point start;

        private List<IController> controllerList;


        //-----Current Objects On Screen-----
        private List<IItem> Items;


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
            graphics.PreferredBackBufferWidth = screenDim.X;
            graphics.PreferredBackBufferHeight = screenDim.Y;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

       /* public void TestArrows()
        {
            double HiIAmAVariable = 2.0;
            Items.Add(new ArrowUpItem(new Point(400, 800), HiIAmAVariable));
            Items.Add(new ArrowRightItem(new Point(50, 500), HiIAmAVariable));
            Items.Add(new ArrowLeftItem(new Point(800, 500), HiIAmAVariable));
            Items.Add(new ArrowDownItem(new Point(500, 50), HiIAmAVariable));
        }

        public void TestSwordBeams()
        {
            double HiIAmAVariable = 2.0;
            Items.Add(new SwordBeamUp(new Point(400, 800), HiIAmAVariable));
            Items.Add(new SwordBeamRight(new Point(50, 500), HiIAmAVariable));
            Items.Add(new SwordBeamLeft(new Point(800, 500), HiIAmAVariable));
            Items.Add(new SwordBeamDown(new Point(500, 50), HiIAmAVariable));
        }

        public void TestBomb()
        {
            double HiIAmAVariable = 2.0;
            Items.Add(new Bomb(new Point(screenDim.X/2, screenDim.Y/2), HiIAmAVariable));
        }
*/
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //---Give All Objects a starting position
           // ItemFactory.Instance.LoadAllTextures(Content);

           /* TestSwordBeams();
            TestArrows();
            TestBomb();*/

          /*  LinkSpriteFactory.Instance.LoadAllTextures(Content);
            link = new Link(new Point(200, 200));*/

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            //enemy = new Jelly(new Point(100, 100));
            enemy =  new Dragon(new Point(500, 500));
        }

        protected override void Update(GameTime gameTime)
        {
            //-------------------------------------------------------
            /*foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            List<IItem> ItemsToRemove = new List<IItem>();
            foreach (IItem item in Items)
            {
                item.Update(gameTime);
                if (!item.SpriteActive())
                {
                    ItemsToRemove.Add(item);
                }
            }
            foreach (IItem item in ItemsToRemove)
            {
                Items.Remove(item);
            }
*/

            //--------------------------------------------------

            //link.Update(gameTime);

            enemy.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.White);

            //link.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
/*
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }*/
            base.Draw(gameTime);
        }
    }
}
