using System;

namespace Game.Scripts.Logic.Mode.Quest
{
    public class ConditionAction : QuestAction
    {
        public bool IsComplete { get; private set; }

        private void Start()
        {
            DoActionEvent += Done;
        }

        private void Done()
        {
            IsComplete = true;
            NextDoAction();
        }
    }
}