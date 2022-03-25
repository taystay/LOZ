using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace LOZ.Sound
{
	class SoundManager
	{
		private SoundEffect soundEffect;
		private Dictionary<String, SoundEffect> sounds;
		private Dictionary<SoundEnum, SoundEffectInstance> loopedSounds;
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
			loopedSounds = new Dictionary<SoundEnum, SoundEffectInstance>();
			//https://www.c-sharpcorner.com/article/loop-through-enum-values-in-c-sharp/
			//https://docs.microsoft.com/en-us/dotnet/api/system.enum.getnames?view=net-6.0
			string[] soundNames = Enum.GetNames(typeof(SoundEnum));

			foreach (string s in soundNames) {
				soundEffect = content.Load<SoundEffect>("LOZ_"+s);
				sounds.Add(s, soundEffect);
			}
        }

        public void SoundToPlayInstance(SoundEnum soundType) {
			sounds[soundType.ToString()].Play();
		}

		public void SoundToLoop(SoundEnum soundType) {

			if (!loopedSounds.ContainsKey(soundType))
			{
				SoundEffectInstance instance = sounds[soundType.ToString()].CreateInstance();
				instance.IsLooped = true;
				instance.Play();
				loopedSounds.Add(soundType, instance);
			}
		}

		public void SoundToNotLoop(SoundEnum soundType)
		{
			if (loopedSounds.ContainsKey(soundType))
			{ 
				loopedSounds[soundType].IsLooped = false;
				loopedSounds[soundType].Stop();
				loopedSounds.Remove(soundType);
			}
		}
	}
}