using System;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementView : MonoBehaviour,ITapable
    {
        private Animator animator;

        [SerializeField] private ItemName itemName;
        public ItemName ItemName => itemName;
        
        public event Action TapEvent;
        public void OnTap()
        {
           
            TapEvent?.Invoke();
        }
        

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void ShowRequirement()
        {
           
            animator.SetTrigger("Show");
        }



    }
}