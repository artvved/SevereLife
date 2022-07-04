using System;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementView : MonoBehaviour
    {
        private Animator animator;

        [SerializeField] private RequirementName requirementName;


        public RequirementName RequirementName => requirementName;

        public Animator Animator => animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        
        
    }
}