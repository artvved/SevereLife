using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.NearInteractable;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementPresenter : IPresenter
    {
        private RequirementView requirementView;
        private RequirementModel requirementModel;
        private InventoryController inventoryController;



        public RequirementPresenter(RequirementView requirementView, RequirementModel requirementModel, InventoryController inventoryController)
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

        


        public void Enable()
        {
           
            requirementView.DoActionEvent += OnDoAction;
        }

        public void Disable()
        {
           
            requirementView.DoActionEvent -= OnDoAction;
        }

        private void OnDoAction()
        {
            //player has required item
            if (inventoryController != null && inventoryController.CheckForItem(requirementModel.ItemName))
            {
                requirementView.NextDoAction();
                if (requirementView.IsDestroyItem)
                {
                    inventoryController.RemoveItem(requirementModel.ItemName);
                }
            }
            else
            {
                requirementView.ShowRequirement();
                requirementView.IsActive = true;
            }
        }




    }
}