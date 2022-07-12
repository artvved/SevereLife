using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementPresenter : IPresenter
    {

        private RequirementView requirementView;
        private RequirementModel requirementModel;
        private InventoryController inventoryController;
        private GameModeModel gameModeModel;

        public RequirementPresenter(RequirementView requirementView, RequirementModel requirementModel, InventoryController inventoryController, GameModeModel gameModeModel)
        {
            this.requirementView = requirementView;
            this.requirementModel = requirementModel;
            this.inventoryController = inventoryController;
            this.gameModeModel = gameModeModel;
        }

        public RequirementPresenter(RequirementView requirementView, RequirementModel requirementModel)
        {
            this.requirementView = requirementView;
            this.requirementModel = requirementModel;
        }


        private void OnTap()
        {
            //player has required item
            if (inventoryController!=null && inventoryController.CheckForItem(requirementModel))
            {
                gameModeModel.OnModeEvent(requirementView);
            }
            else
            {
                requirementView.ShowRequirement();
            }
        }


        public void Enable()
        {
            requirementView.TapEvent += OnTap;
            requirementView.DestroyEvent += OnDestroy;
        }

        public void Disable()
        {
            requirementView.TapEvent -= OnTap;
            requirementView.DestroyEvent -= OnDestroy;
        }


        private void OnDestroy()
        {
            Disable();
            if (requirementView.NextInSequence==null && requirementView.RewardItemModel!=null)
            {
                //inventoryController.RemoveItem();
                inventoryController.AddItem(requirementView.RewardItemModel);
            }
            else
            {
                requirementView.NextInSequence?.ActivateSelf();
            }

        }
    }
}