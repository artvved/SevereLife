using System;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class CirclesTapMode : GameModeModel
    {
        public override event Action<RequirementView> ModeEvent;

        public override void OnModeEvent(RequirementView requirementView)
        {
            ModeEvent?.Invoke(requirementView);
        }
    }
}