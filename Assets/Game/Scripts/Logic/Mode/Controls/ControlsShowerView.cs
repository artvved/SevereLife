using System;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic.Mode
{
    public class ControlsShowerView : QuestAction
    {
        [SerializeField] private bool show;
        [SerializeField] private bool doOnAwake;
        public bool Show => show;

        private void Start()
        {
            if (doOnAwake)
            {
                DoAction();
                
            }
        }
    }
}