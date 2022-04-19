
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses;
using LOZ.SpriteClasses.EnemeySprite;

namespace LOZ.Factories
{
	class EnemySpriteFactory
	{
		private Texture2D enemySpriteSheet;
		private Texture2D dragonsBreatheSprite;
		private Texture2D npc;
		private Texture2D spikeTrap;
		private Texture2D skeletonBoss;
		private static EnemySpriteFactory instance = new EnemySpriteFactory();
		public static EnemySpriteFactory Instance { get { return instance; } }
		private EnemySpriteFactory() { }
		public void LoadAllTextures(ContentManager content)
		{
			enemySpriteSheet = content.Load<Texture2D>("enemySprite");
            dragonsBreatheSprite = content.Load<Texture2D>("dragonsBreathe");
			npc = content.Load<Texture2D>("oldMan");
			spikeTrap = content.Load<Texture2D>("spikeTrap");
			skeletonBoss = content.Load<Texture2D>("Custom_Edited_-_Terraria_Customs_-_Skeletron__Skeletron_Prime_NES-Style");
        }

		public ISpriteRotatable CreateSkeletronHand(bool leftHand) => new SkeletronHand(skeletonBoss, leftHand);
		public ISpriteRotatable CreateArmBone(bool leftHand) => new SkeletronBone(skeletonBoss, leftHand);
		public ISpriteRotatable CreateSkeletonHead() => new SkeletronHead(skeletonBoss);
        public ISprite CreateBat() => new BatSprite(enemySpriteSheet);
        public ISprite CreateSkeleton() => new SkeletonSprite(enemySpriteSheet);
        public ISprite CreateJelly() => new JellySprite(enemySpriteSheet);
		public ISprite CreateDragon() => new DragonSprite(enemySpriteSheet);
        public ISprite CreateFireBall() => new DragonsFireSprite(dragonsBreatheSprite);
		public ISprite CreateNPC() => new NPCSprite(npc);
		public ISprite CreateTrap() => new SpikeTrapSprite(spikeTrap);
	}
}
