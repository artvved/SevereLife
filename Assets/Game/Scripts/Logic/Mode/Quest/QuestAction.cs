using System;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Quest
{
    public class QuestAction : MonoBehaviour
    {
        public bool IsActive { get; set; }
        
        public virtual event Action BackEvent;

        public virtual void OnBack()
        {
         
            BackEvent?.Invoke();
        }

        public virtual event Action NextEvent;
        
        public virtual void OnNext()
        {
            IsActive = false;
            NextEvent?.Invoke();
        }
        public virtual event Action DoActionEvent;
        public virtual void DoAction()
        {
          
            if (IsActive)
            {
             
               
              
                DoActionEvent?.Invoke();
            }
           
        }
        public virtual event Action NextDoActionEvent;
        public virtual void OnNextDoAction()
        {
            IsActive = false;
          
            NextDoActionEvent?.Invoke();
        }
    }
}