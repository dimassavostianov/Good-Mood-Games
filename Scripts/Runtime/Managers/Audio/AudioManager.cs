using GoodMoodGames.Scripts.Runtime.Patterns.Singleton;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Managers.Audio
{
    public sealed class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [SerializeField] private AudioSource _soundsAudioSource;
        [SerializeField] private AudioSource _musicAudioSource;

        public static bool SoundsEnabled => PlayerPrefs.GetInt("AudioManager_SoundsEnabled", 1) == 1;
        
        public void EnableSounds(bool enable) => PlayerPrefs.SetInt("AudioManager_SoundsEnabled", enable ? 1 : 0);

        public void PlaySound(AudioClip audioClip, float volumeScale = 1)
        {
            if (!SoundsEnabled) return;
            if (audioClip == null) return;

            _soundsAudioSource.PlayOneShot(audioClip, volumeScale);
        }

        public void PlayMusic(AudioClip audioClip, bool loop = false)
        {
            if (!SoundsEnabled) return;
            if (audioClip == null) return;

            _musicAudioSource.clip = audioClip;
            _musicAudioSource.loop = loop;

            _musicAudioSource.Play();
        }
    }
}