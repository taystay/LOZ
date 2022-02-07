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
        public int Item { get; set; }
        public Point ItemLocation { get; set; } = new Point(500, 500);
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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            linkItems = new List<IItem>();
            double scale = 3.0;
            items = new List<IItem>()
            {
                { new ArrowItem(ItemLocation, scale) },
                { new Bow(ItemLocation, scale) },
                { new Clock(ItemLocation, scale) },
                { new Compass(ItemLocation, scale) },
                { new Fairy(ItemLocation, scale) },
                { new FireItem(ItemLocation, scale) },
                { new Heart(ItemLocation, scale) },
                { new HeartContainer(ItemLocation, scale) },
                { new Key(ItemLocation, scale) },
                { new Map(ItemLocation, scale) },
                { new Rupee(ItemLocation, scale) },
                { new Triforce(ItemLocation, scale) },
            };

            link = new Link(new Point(200, 200));       
            enemy = new Dragon(new Point(800, 800));

        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }

            if (Item >= items.Count)
                Item = 0;
            if (Item < 0)
                Item = items.Count - 1;
            items[Item].Update(gameTime);

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

            //--------------------------------------------------
            link.Update(gameTime);
            enemy.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            link.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            items[Item].Draw(spriteBatch);

            foreach (IItem item in linkItems)
            {
                item.Draw(spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
