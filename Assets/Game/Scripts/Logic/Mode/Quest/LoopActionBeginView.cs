using System;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Quest
{
    public class LoopActionBeginView : QuestAction
    {
        
        [SerializeField] private int count;

        public int Count => count;

        private void Start()
        {
            DoActionEvent += NextDoAction;
        }
    }
}