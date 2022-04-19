using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LOZ.SpriteClasses.LinkSprites;
using LOZ.SpriteClasses;


namespace LOZ.Factories
{
	class LinkSpriteFactory
	{
		private Texture2D linkSpriteSheet;
		private static LinkSpriteFactory instance = new LinkSpriteFactory();
		public static LinkSpriteFactory Instance { get {return instance;} }
		private LinkSpriteFactory() { }
		public void LoadAllTextures(ContentManager content)
		{
			linkSpriteSheet = content.Load<Texture2D>("LinkSprites");
		}
        public ISprite LinkDownIdle() =>
			new LinkDownIdle(linkSpriteSheet);   
		public ISprite LinkUpIdle() =>
			new LinkUpIdle(linkSpriteSheet);
		public ISprite LinkLeftIdle() =>
			new LinkLeftIdle(linkSpriteSheet);
		public ISprite LinkRightIdle() =>
			new LinkRightIdle(linkSpriteSheet);
		public ISprite LinkMovingUp() =>
			new LinkMovingUp(linkSpriteSheet);
		public ISprite LinkMovingDown() =>
			new LinkMovingDown(linkSpriteSheet);
		public ISprite LinkMovingLeft() =>
			new LinkMovingLeft(linkSpriteSheet);
		public ISprite LinkMovingRight() =>
			new LinkMovingRight(linkSpriteSheet);
		public ISprite LinkLeftAttack() =>
			new LinkLeftAttack(linkSpriteSheet);
		public ISprite LinkRightAttack() =>
			new LinkRightAttack(linkSpriteSheet);
		public ISprite LinkUpAttack() =>
			new LinkUpAttack(linkSpriteSheet);
		public ISprite LinkDownAttack() =>
			new LinkDownAttack(linkSpriteSheet);
		public ISprite LinkItemLeftAttack() =>
			new LinkItemLeftAttack(linkSpriteSheet);
		public ISprite LinkItemRightAttack() =>
			new LinkItemRightAttack(linkSpriteSheet);
		public ISprite LinkItemUpAttack() =>
			new LinkItemUpAttack(linkSpriteSheet);
		public ISprite LinkItemDownAttack() =>
			new LinkItemDownAttack(linkSpriteSheet);
		public ISprite LinkRaiseItem() =>
			new LinkRaiseItem(linkSpriteSheet);
		public ISprite LinkDead() =>
			new LinkDead(linkSpriteSheet);
	}
}
