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
            //Debug.Log("next "+this);
            IsActive = false;
            NextEvent?.Invoke();
        }
        public virtual event Action DoActionEvent;
        public virtual void DoAction()
        {
           //Debug.Log("do act "+ IsActive+" + "+this);
            if (IsActive)
            {
                IsActive = false;
                DoActionEvent?.Invoke();
            }
           
        }
        public virtual event Action NextDoActionEvent;
        public virtual void NextDoAction()
        {
            //Debug.Log("next do act "+this);
            IsActive = false;
          
            NextDoActionEvent?.Invoke();
        }
    }
}