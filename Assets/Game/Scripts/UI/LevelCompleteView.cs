using System;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class LevelCompleteView : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public bool IsFinished { get; set; }

        public void OnFinishedShow()
        {
            IsFinished = true;
        }

        public void Show()
        {
            IsFinished = false;
            animator.SetTrigger("Show");
        }
        
        public void Idle()
        {
            IsFinished = false;
            animator.SetTrigger("Idle");
        }
    }
}