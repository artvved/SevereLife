using Game.Scripts.Logic.Sequence;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Quest
{
    public class AndConditionView : QuestAction
    {
        [SerializeField] private ConditionAction[] conditionActions;
      
        private void Start()
        {
           
            DoActionEvent += CheckCondition;
        }

        private void CheckCondition()
        {
            bool isDone = true;
            foreach (var q in conditionActions)
            {
                if (!q.IsComplete)
                {
                    isDone = false;
                    break;
                }
            }
            
            if (isDone)
            {
                NextDoAction();
            }
        }

        
    }
}