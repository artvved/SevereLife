using System;
using Game.Scripts.Logic.Mode.Quest;
using Game.Scripts.Logic.Sequence;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementView : QuestAction
    {
        [SerializeField] private Animator animator;

        [SerializeField] private ItemName itemName;
        [SerializeField] private bool isDestroyItem;


        public ItemName ItemName => itemName;

        public bool IsDestroyItem => isDestroyItem;

      
        

        public void ShowRequirement()
        {
            animator.SetTrigger("Show");
        }

     

       


       
    }
}