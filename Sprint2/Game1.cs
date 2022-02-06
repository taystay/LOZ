using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;  

namespace Sprint2
{
    public class Game1 : Game
    {
        //-----MON0GAME STUFF----
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //-----------------------
        private Point screenDimensions;
        private List<IController> controllerList;
        
        //----------------------
        private List<IItem> linkItems;
        private List<IItem> items;
        private int currentItem;
        private Point itemLocation = new Point(500, 500);
        public Point ItemLocation
        {
            get
            {
                return itemLocation;
            }
        }

        public int Item
        {
            get
            {
                return currentItem;
            }
            set
            {
                currentItem = value;
            }
        }

        private IEnemy enemy;
        private ILink link;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screenDimensions = new Point(GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetController()},
            };
            
            

            /*
             * Allows for a screen that is always the size of the user 
             * https://community.monogame.net/t/get-the-actual-screen-width-and-height-on-windows-10-c-monogame/10006
             */
            graphics.PreferredBackBufferWidth = screenDimensions.X;
            graphics.PreferredBackBufferHeight = screenDimensions.Y;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
<<<<<<< HEAD
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
=======
>>>>>>> 1a3910bff0a29d49567842cb3e763b998bd45f12

            base.Initialize();
        }
*/
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

<<<<<<< HEAD
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
=======
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            linkItems = new List<IItem>();
            double scale = 3.0;
            items = new List<IItem>()
            {
                { new ArrowItem(itemLocation, scale) },
                { new Bow(itemLocation, scale) },
                { new Clock(itemLocation, scale) },
                { new Compass(itemLocation, scale) },
                { new Fairy(itemLocation, scale) },
                { new FireItem(itemLocation, scale) },
                { new Heart(itemLocation, scale) },
                { new HeartContainer(itemLocation, scale) },
                { new Key(itemLocation, scale) },
                { new Map(itemLocation, scale) },
                { new Rupee(itemLocation, scale) },
                { new Triforce(itemLocation, scale) },
            };

            link = new Link(new Point(200, 200));       
            //enemy = new Jelly(new Point(100, 100));
            enemy = new Skeleton(new Point(100, 100));

>>>>>>> 1a3910bff0a29d49567842cb3e763b998bd45f12
        }

        protected override void Update(GameTime gameTime)
        {
<<<<<<< HEAD
            //-------------------------------------------------------
            /*foreach (IController controller in controllerList)
=======
            foreach (IController controller in controllerList)
>>>>>>> 1a3910bff0a29d49567842cb3e763b998bd45f12
            {
                controller.Update(gameTime);
            }

            if (currentItem >= items.Count)
                currentItem = 0;
            items[currentItem].Update(gameTime);

            // Allows for items to remove themselves.
            int i = 0;
            while(i < linkItems.Count)
            {
                IItem item = linkItems[i];
                item.Update(gameTime);
                if(!item.SpriteActive())
                {
                    linkItems.RemoveAt(i);
                    continue;
                }
                i++;
            }
<<<<<<< HEAD
            foreach (IItem item in ItemsToRemove)
            {
                Items.Remove(item);
            }
*/

            //--------------------------------------------------

            //link.Update(gameTime);

=======
            //--------------------------------------------------
            link.Update(gameTime);
>>>>>>> 1a3910bff0a29d49567842cb3e763b998bd45f12
            enemy.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.White);

            //link.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
<<<<<<< HEAD
/*
            foreach (IItem item in Items)
=======

            items[currentItem].Draw(spriteBatch);

            foreach (IItem item in linkItems)
>>>>>>> 1a3910bff0a29d49567842cb3e763b998bd45f12
            {
                item.Draw(spriteBatch);
            }*/
            base.Draw(gameTime);
        }
    }
}
