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

        private List<IController> controllerList;
<<<<<<< HEAD
        
        //----------------------
        private List<IItem> linkItems;
        private List<IItem> items;
        public int Item { get; set; }
        public Point ItemLocation { get; set; } = new Point(500, 500);
        private IEnemy enemy;
        private List<IProjectile> projectiles;
        private ILink link;

=======
>>>>>>> 59f8a418948ef80ba9225bed212a8b8d956ce1c8
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

            controllerList = new List<IController>()
            {
                { new KeyBindings(this).GetController()},
            };

<<<<<<< HEAD
            projectiles = new List<IProjectile>();

            /*
             * Allows for a screen that is always the size of the user 
             * https://community.monogame.net/t/get-the-actual-screen-width-and-height-on-windows-10-c-monogame/10006
             */
            graphics.PreferredBackBufferWidth = screenDimensions.X;
            graphics.PreferredBackBufferHeight = screenDimensions.Y;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

=======
>>>>>>> 59f8a418948ef80ba9225bed212a8b8d956ce1c8
            base.Initialize();
        }

        protected override void LoadContent()
        {
<<<<<<< HEAD
            spriteBatch = new SpriteBatch(GraphicsDevice);
/*
            ItemFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);*/
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

           /* linkItems = new List<IItem>();
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

            link = new Link(new Point(200, 200));*/
            enemy = new Dragon(new Point(800, 800), projectiles);

=======
            spriteBatch = new SpriteBatch(GraphicsDevice);         
            GameObjects.Instance.LoadObjects(Content);
>>>>>>> 59f8a418948ef80ba9225bed212a8b8d956ce1c8
        }

        protected override void Update(GameTime gameTime)
        {
<<<<<<< HEAD
            /* foreach (IController controller in controllerList)
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
 */
            //--------------------------------------------------
            /*     link.Update(gameTime);*/


            //------------------------------------------
            enemy.Update(gameTime);

            int k;
            for (k = 0; k < projectiles.Count; k++)
            {
                projectiles[k].Update(gameTime);

                if (!projectiles[k].IsActive())
                {
                    projectiles.RemoveAt(k);
                    continue;
                }

            }



=======
            foreach (IController controller in controllerList)
            {
                controller.Update(gameTime);
            }
            GameObjects.Instance.UpdateObjects(gameTime); 
>>>>>>> 59f8a418948ef80ba9225bed212a8b8d956ce1c8
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
<<<<<<< HEAD

            //link.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            foreach (IProjectile FireBall in projectiles) {
                FireBall.Draw(spriteBatch);
            
            }
            
           /* items[Item].Draw(spriteBatch);

            foreach (IItem item in linkItems)
            {
                item.Draw(spriteBatch);
            }*/
=======
            GameObjects.Instance.DrawObjects(spriteBatch);
>>>>>>> 59f8a418948ef80ba9225bed212a8b8d956ce1c8
            base.Draw(gameTime);
        }
    }
}
