using System;
using UnityEngine;

namespace Game.Scripts.Logic.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundView : MonoBehaviour
    {
        
       private AudioSource source;

       private void Start()
       {
           source = GetComponent<AudioSource>();
       }

       public void Play(AudioClip audioClip)
        {
            source.clip = audioClip;
            source.Play();
        }
        public void Play()
        {
            source.Play();
        }
        public void Stop()
        {
            source.Stop();
        }
    }
}