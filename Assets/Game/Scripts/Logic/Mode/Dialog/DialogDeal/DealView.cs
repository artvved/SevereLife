using System;
using Game.Scripts.Logic.Audio;
using UnityEngine;

namespace Game.Scripts.Logic.Dialog
{
   
    public class DealView: MonoBehaviour
    {
        [SerializeField] private bool isActive;
        private Animator animator;

        public bool IsActive => isActive;

        private bool idleActive;
        private Vector3 idlePos;
        private SoundEffect soundEffect;

        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            idleActive = isActive;
            idlePos=transform.position;
            soundEffect = GetComponent<SoundEffect>();
        }

        public void Activate()
        {
            isActive = true;
        }
        public void Deactivate()
        {
            isActive = false;
        }


        public void PlaySound()
        {
            soundEffect.StartEffect();
        }
        
        public void HideDeal()
        {
            animator.SetTrigger("Hide");
        }

        public void ShowDeal()
        {
            animator.SetTrigger("Show");
        }

        public void ToIdle()
        {
            isActive = idleActive;
            transform.position = idlePos;
            //animator.SetTrigger("Idle");
        }
    }
}