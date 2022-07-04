using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementHolder: MonoBehaviour
    {
        [SerializeField] private RequirementView requirementView;

        public RequirementView RequirementView => requirementView;
    }
}