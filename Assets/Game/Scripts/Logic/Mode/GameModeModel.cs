using System;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public abstract class GameModeModel: MonoBehaviour
    {
        public abstract event Action<RequirementView> ModeEvent;

        public abstract void OnModeEvent(RequirementView requirementView);
    }
}