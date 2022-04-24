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
		private SoundManager() { }

		public static SoundManager Instance { get { return instance; } }
		public void LoadSound(ContentManager content)
		{
			mute = false;
			sounds = new Dictionary<string, SoundEffectInstance>();
			string[] soundNames = Enum.GetNames(typeof(SoundEnum));
			foreach (string s in soundNames) {
				soundEffect = content.Load<SoundEffect>("LOZ_" + s);
				sounds.Add(s, soundEffect.CreateInstance());
			}
			sounds["Background"].IsLooped = true;
			sounds["Background"].Volume = 0.1f;
			sounds["Background"].Play();
			sounds["PortalShot"].Volume = 0.25f;
		}

		public void SoundToPlayInstance(SoundEnum soundType) {
			if (!mute) sounds[soundType.ToString()].Play();
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