using System;
using Game.Scripts.Logic.Audio;
using Game.Scripts.Logic.Mode.Move;
using UnityEngine;

namespace Game.Scripts.Logic.Terrain
{
    public class VisualEffect : Effect

    {
        [SerializeField] private Animator animator;
        [SerializeField] private string startAnimationName;
        [SerializeField] private string stopAnimationName;

        private void Start()
        {
            if (string.IsNullOrEmpty(startAnimationName) )
            {
                startAnimationName = "Start";
            }
            
            if (string.IsNullOrEmpty(stopAnimationName) )
            {
                stopAnimationName = "Idle";
            }
        }

        

        public override void StartEffect()
        {
          
            animator.SetTrigger(startAnimationName);
        }

        public override void StopEffect()
        {
            animator.SetTrigger(stopAnimationName);
        }
    }
}