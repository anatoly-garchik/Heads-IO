using System.Collections;
using UnityEngine;

namespace _Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _scream;

        public void PlayAudioClip()
        {
            _audioSource.volume = 1;
            _audioSource.PlayOneShot(_scream);
        }

        public void StopAllClips()
        {
            StartCoroutine(Stop());
            IEnumerator Stop()
            {
                while (_audioSource.volume > 0)
                {
                    _audioSource.volume -= 0.1f;
                    yield return null;
                }
            }
            _audioSource.Stop();
        }
    }
}
