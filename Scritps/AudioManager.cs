using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManager
{
    public class AudioManager : MonoBehaviour
    {
       
        [Header("Music")]
        public AudioClip Music;

        [Space(5f)]
        [Header("Sounds")]
        public AudioClip[] sounds;

        [Space(5f)]
        [Header("Links")]
        [SerializeField] AudioSource ForMusic;
        [SerializeField] AudioSource ForSound;




        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        public void PlayHit() => ForSound.PlayOneShot(sounds[0]);
        public void PlayShot() => ForSound.PlayOneShot(sounds[1]);
        public void PlayKnifeToKnife() => ForSound.PlayOneShot(sounds[2]);
        public void PlayWin() => ForSound.PlayOneShot(sounds[3]);
        public void PlayLoose() => ForSound.PlayOneShot(sounds[4]);
        public void PlayDeadWood() => ForSound.PlayOneShot(sounds[5]);
    }

}