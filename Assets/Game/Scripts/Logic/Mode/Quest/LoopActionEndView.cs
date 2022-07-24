using System;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Quest
{
    public class LoopActionEndView : QuestAction
    {
        [SerializeField] private LoopActionBeginView begin;
        private int i=1;
        private void Start()
        {
            DoActionEvent += EndLoop;
        }

        private void EndLoop()
        {
            if (i<begin.Count)
            {
                begin.IsActive = true;
                begin.DoAction();
                i++;
            }
            else
            {
                NextDoAction();
            }
        }
    }
}