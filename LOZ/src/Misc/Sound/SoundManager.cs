using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace LOZ.Sound
{
	class SoundManager
	{
		private SoundEffect soundEffect;
		private Dictionary<String, SoundEffect> sounds;
		private static SoundManager instance = new SoundManager();
		public static SoundManager Instance
		{
			get
			{
				return instance;
			}
		}

		private SoundManager()
		{
		}

		public void LoadSound(ContentManager content)
        {
			sounds = new Dictionary<string, SoundEffect>();
			//https://www.c-sharpcorner.com/article/loop-through-enum-values-in-c-sharp/
			//https://docs.microsoft.com/en-us/dotnet/api/system.enum.getnames?view=net-6.0
			string[] soundNames = Enum.GetNames(typeof(SoundEnum));

			foreach (string s in soundNames) {
				soundEffect = content.Load<SoundEffect>("LOZ_"+s);
				sounds.Add(s, soundEffect);
			}
        }

        public void SoundToPlay(SoundEnum soundType) {
			sounds[soundType.ToString()].Play();
		}
	}
}