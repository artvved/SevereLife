using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementPresenter : IPresenter
    {

        private RequirementView requirementView;
        private RequirementModel requirementModel;

        public RequirementPresenter(RequirementView requirementView, RequirementModel requirementModel)
        {
            this.requirementView = requirementView;
            this.requirementModel = requirementModel;
        }

        private void OnTap()
        {
            
            requirementView.ShowRequirement();
        }


        public void Enable()
        {
            requirementView.TapEvent += OnTap;

        }

        public void Disable()
        {
            requirementView.TapEvent -= OnTap;
        }
    }
}