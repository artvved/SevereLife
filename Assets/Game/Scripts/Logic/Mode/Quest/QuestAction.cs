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
            Debug.Log("on back"+ this);
            BackEvent?.Invoke();
        }

        public virtual event Action NextEvent;
        
        public virtual void OnNext()
        {
            Debug.Log("on next "+ this);
            NextEvent?.Invoke();
        }
        public virtual event Action DoActionEvent;
        public virtual void DoAction()
        {
           //Debug.Log("Do action "+ this);
            if (IsActive)
            {
                IsActive = false;
                Debug.Log("Do action true" + this);
                DoActionEvent?.Invoke();
            }
           
        }
        public virtual event Action NextDoActionEvent;
        public virtual void OnNextDoAction()
        {
            Debug.Log("on next do act "+ this);
            NextDoActionEvent?.Invoke();
        }
    }
}