using System;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Move
{
  
    public class MoveAnimationEffect: Effect
    {

        [SerializeField] private MoveType moveType;
        [SerializeField] private Animator animator;

      /*  private void Start()
        {
            animator = GetComponent<Animator>();
        }*/


        public override void StartEffect()
        {
            if (moveType.Equals(MoveType.WALK))
            {
                animator.SetTrigger("Walk");   
            }
            else
            {
                animator.SetTrigger("Run");   
            }
        }

        public override void StopEffect()
        {
            animator.SetTrigger("Idle");   
        }
    }
}