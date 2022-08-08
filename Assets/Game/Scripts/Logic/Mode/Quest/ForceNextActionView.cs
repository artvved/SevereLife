using System;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Quest
{
    public class ForceNextActionView : QuestAction
    {
        [SerializeField] private QuestAction questAction;

        private void Start()
        {
            questAction.NextEvent += questAction.NextDoAction;
            this.DoActionEvent += NextDoAction;
        }
    }
}