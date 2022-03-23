using Microsoft.Xna.Framework.Audio;
using System;
using Microsoft.Xna.Framework.Content;

namespace LOZ.Sound
{
	class SoundFactory
	{
		private SoundEffect soundEffect;
		private ContentManager contentManager;
		private static SoundFactory instance = new SoundFactory();
		public static SoundFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private SoundFactory()
		{
		}

		public void LoadContentManager(ContentManager content)
		{
			contentManager = content;
		}

		public void SoundToPlay(SoundEnum soundType) {

			switch (soundType) {
				case SoundEnum.BombDrop:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Bomb_Drop");
					break;
				case SoundEnum.BombBlow:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Bomb_Blow");
					break;
				case SoundEnum.BossHit:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Boss_Hit");
					break;
				case SoundEnum.BossScream:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Boss_Scream1");
					break;
				case SoundEnum.DoorUnlock:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Door_Unlock");
					break;
				case SoundEnum.EnemyDie:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Enemy_Die");
					break;
				case SoundEnum.EnemyHit:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Enemy_Hit");
					break;
				case SoundEnum.Fanfare:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Fanfare");
					break;
				case SoundEnum.GetHeart:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Get_Heart");
					break;
				case SoundEnum.GetItem:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Get_Item");
					break;
				case SoundEnum.GetRupee:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Get_Rupee");
					break;
				case SoundEnum.KeyAppear:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Key_Appear");
					break;
				case SoundEnum.LinkDie:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Link_Die");
					break;
				case SoundEnum.LinkHurt:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Link_Hurt");
					break;
				case SoundEnum.LowHealth:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_LowHealth");
					break;
				case SoundEnum.Recorder:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Recorder");
					break;
				case SoundEnum.RefillLoop:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Refill_Loop");
					break;
				case SoundEnum.Secret:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Secret");
					break;
				case SoundEnum.Stairs:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Stairs");
					break;
				case SoundEnum.SwordCombo:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Sword_Combined");
					break;
				case SoundEnum.SwordShoot:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Sword_Shoot");
					break;
				case SoundEnum.SwordSlash:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Sword_Slash");
					break;
				case SoundEnum.Text:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Text");
					break;
				case SoundEnum.TextSlow:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Text_Slow");
					break;
				default:
					soundEffect = contentManager.Load<SoundEffect>("LOZ_Boss_Scream1");
					break;
			}

			SoundEffectInstance sInstance = soundEffect.CreateInstance();
			sInstance.Play();
		}
	}
}