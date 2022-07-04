using UnityEngine;

namespace Game.Scripts.Logic
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private RequirementHolder[] requirementHolders;

        public RequirementHolder[] RequirementHolders => requirementHolders;
    }
}