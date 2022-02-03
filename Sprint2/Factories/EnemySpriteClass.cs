using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
	class EnemySpriteFactory
	{
		private Texture2D enemySpriteSheet;
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
		}

		public ISprite CreateBat() {

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
	}
}
