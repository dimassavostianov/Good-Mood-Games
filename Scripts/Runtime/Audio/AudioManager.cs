using GoodMoodGames.Scripts.Runtime.Patterns.Singleton;
using UnityEngine;

namespace GoodMoodGames.Scripts.Runtime.Audio
{
    public sealed class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [SerializeField] private AudioSource _soundsAudioSource;
        [SerializeField] private AudioSource _musicAudioSource;
        
        public void PlaySound(AudioClip audioClip)
        {
            _soundsAudioSource.PlayOneShot(audioClip);
        }
        
        public void PlayMusic(AudioClip audioClip, bool loop = false)
        {
            _musicAudioSource.clip = audioClip;
            _musicAudioSource.loop = loop;

            _musicAudioSource.Play();
        }
    }
}