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
        
        //-----------------------
        private List<IItem> linkItems;
        private List<IEnvironment> blocks;
        public int Block { get; set; }
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
            BlockSpriteFactory.Instance.LoadAllTextures(Content);

            linkItems = new List<IItem>();
            double scale = 3.0;

            blocks = new List<IEnvironment>()
            {
                { new BlueSandBlock(new Point(400, 400), scale) },
                { new BlackTileBlock(new Point(400, 400), scale) },
                { new BlueTriangleBlock(new Point(400, 400), scale) },
                { new DarkBlueBlock(new Point(400, 400), scale) },
                { new MulticoloredBlock1(new Point(400, 400), scale) },
                { new MulticoloredBlock2(new Point(400, 400), scale) },
                { new SolidBlueBlock(new Point(400, 400), scale) },
                { new StairsBlock(new Point(400, 400), scale) },
            };
            GameObjects.Instance.AddSprint2Items();
            
            link = new Link(new Point(200, 200));       
            enemy = new Dragon(new Point(800, 800));

        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }

            

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

            GameObjects.Instance.UpdateItems(gameTime);

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
            GameObjects.Instance.DrawItems(spriteBatch);
            blocks[Block].Draw(spriteBatch);

            foreach (IItem item in linkItems)
            {
                item.Draw(spriteBatch);
            }
            base.Draw(gameTime);
        }
    }
}
