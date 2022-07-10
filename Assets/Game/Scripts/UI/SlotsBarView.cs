using System;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class SlotsBarView : MonoBehaviour
    {
        private Animator animator;
        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        public void ShowSlots()
        {
            animator.SetTrigger("Show");
        }

        public void HideSlots()
        {
            animator.SetTrigger("Hide");
        }
    }
}