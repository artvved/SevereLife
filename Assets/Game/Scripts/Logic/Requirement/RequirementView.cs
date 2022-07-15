using System;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementView : MonoBehaviour, ITapable
    {
        [SerializeField] private Animator animator;

        [SerializeField] private ItemName itemName;


        public ItemName ItemName => itemName;
      
        public event Action TapEvent;

        public void OnTap()
        {
            
            TapEvent?.Invoke();
        }

        

        public void ShowRequirement()
        {
            animator.SetTrigger("Show");
        }

     

        public void Destroy()
        {
            Destroy(this);
           // StartCoroutine(WaitAndDestroy(1f));
        }

       
    }
}