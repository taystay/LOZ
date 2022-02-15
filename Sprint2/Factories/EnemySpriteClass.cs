
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.SpriteClasses.EnemeySprite;

namespace Sprint2.Factories
{
	class EnemySpriteFactory
	{
		private Texture2D enemySpriteSheet;
		private Texture2D dragonsBreatheSprite;
		private Texture2D npc;
		// More private Texture2Ds follow
		// ...

		private static EnemySpriteFactory instance = new EnemySpriteFactory();

		public static EnemySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private EnemySpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			enemySpriteSheet = content.Load<Texture2D>("enemySprite");
            dragonsBreatheSprite = content.Load<Texture2D>("dragonsBreathe");
			npc = content.Load<Texture2D>("oldMan");

        }

        public ISprite CreateBat()
        {

            return new BatSprite(enemySpriteSheet);

        }

        public ISprite CreateSkeleton()
		{

			return new SkeletonSprite(enemySpriteSheet);

		}

        public ISprite CreateJelly()
        {

            return new JellySprite(enemySpriteSheet);

        }
		public ISprite CreateDragon()
        {

            return new DragonSprite(enemySpriteSheet);

        }

        public ISprite CreateFireBall()
        {
            return new DragonsFireSprite(dragonsBreatheSprite);
        }

		public ISprite CreateNPC()
		{
			return new NPCSprite(npc);
		}





	}
}
