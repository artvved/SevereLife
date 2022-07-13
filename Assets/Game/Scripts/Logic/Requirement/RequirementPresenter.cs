using Game.Scripts.Logic.Mode;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementPresenter : IPresenter
    {
        private RequirementView requirementView;
        private RequirementModel requirementModel;
        private InventoryController inventoryController;
       

        public RequirementPresenter(RequirementView requirementView, RequirementModel requirementModel,
            InventoryController inventoryController)
        {
            this.requirementView = requirementView;
            this.requirementModel = requirementModel;
            this.inventoryController = inventoryController;
        }

        public RequirementPresenter(RequirementView requirementView, RequirementModel requirementModel)
        {
            this.requirementView = requirementView;
            this.requirementModel = requirementModel;
        }


        private void OnTap()
        {
            //player has required item
            if (inventoryController != null && inventoryController.CheckForItem(requirementModel.ItemName))
            {
                requirementView.Destroy();
                Disable();
                
            }
            else
            {
                requirementView.ShowRequirement();
            }
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