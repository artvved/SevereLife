using System;
using Game.Scripts.Logic.Mode.Move;
using UnityEngine;

namespace Game.Scripts.Logic.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffect : Effect
    {
        
       private AudioSource source;

       private void Start()
       {
           source = GetComponent<AudioSource>();
       }

       public override void StartEffect()
        {
            source.Play();
        }

        public override void StopEffect()
        {
            source.Stop();
        }
    }
}