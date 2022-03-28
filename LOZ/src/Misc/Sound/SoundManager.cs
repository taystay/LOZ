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
		private Dictionary<String, SoundEffectInstance> sounds;
		private static SoundManager instance = new SoundManager();
		private bool mute;

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
			mute = false;
			sounds = new Dictionary<string, SoundEffectInstance>();

			//https://www.c-sharpcorner.com/article/loop-through-enum-values-in-c-sharp/
			//https://docs.microsoft.com/en-us/dotnet/api/system.enum.getnames?view=net-6.0
			string[] soundNames = Enum.GetNames(typeof(SoundEnum));

			foreach (string s in soundNames) {
				soundEffect = content.Load<SoundEffect>("LOZ_"+s);
				sounds.Add(s, soundEffect.CreateInstance());
			}

			sounds["Background"].IsLooped = true;
			sounds["Background"].Volume = 0.1f;
			sounds["Background"].Play();
        }

        public void SoundToPlayInstance(SoundEnum soundType) {

			if(!mute) sounds[soundType.ToString()].Play();
		}

		public void SoundToLoop(SoundEnum soundType) {

			if (!mute)
			{
				sounds[soundType.ToString()].IsLooped = true;
				sounds[soundType.ToString()].Play();
			}
		}

		public void SoundToNotLoop(SoundEnum soundType)
		{
			if (!mute)
			{
				sounds[soundType.ToString()].IsLooped = false;
				sounds[soundType.ToString()].Stop();
			}
		}

		public void ToggleMute() {
            mute = !mute;
            int i = 0;
            if (mute)
            {
                foreach (KeyValuePair<String, SoundEffectInstance> s in sounds)
                {
                    s.Value.Pause();
                }
            }
            else
            {
                foreach (KeyValuePair<String, SoundEffectInstance> s in sounds)
                {
                    s.Value.Resume();
                    if ( !s.Key.Equals(SoundEnum.Background.ToString())  && !s.Key.Equals(SoundEnum.LowHealth.ToString()) ) s.Value.Stop();
                }
            }

        }
	}
}