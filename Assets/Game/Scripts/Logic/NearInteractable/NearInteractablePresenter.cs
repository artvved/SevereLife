using System;
using System.Collections;
using Game.Scripts.Logic.Mode;
using UnityEngine;

namespace Game.Scripts.Logic.NearInteractable
{
    public class NearInteractablePresenter : IPresenter
    {
        private NearInteractableView nearInteractableView;
        private PlayerView playerView;
        private IModeTriggerView modeTriggerView;
        private InventoryController inventoryController;
        private bool isItemRequired;

        public NearInteractablePresenter(NearInteractableView nearInteractableView, PlayerView playerView,
            InventoryController inventoryController)
        {
            this.nearInteractableView = nearInteractableView;
            this.playerView = playerView;
            modeTriggerView = nearInteractableView.ModeTriggerView;
            isItemRequired = !this.nearInteractableView.RequiredItemName.Equals(ItemName.NOTHING);
           
            this.inventoryController = inventoryController;
        }

        private void OnTap()
        {
         
            if (!isItemRequired)
            {
               
                playerView.OnShowHideControls();
                playerView.OnGoTo(nearInteractableView.StartPosition.transform);
                nearInteractableView.StartCoroutine(WaitForApproach());
            }
            else if (inventoryController != null &&
                     inventoryController.CheckForItem(nearInteractableView.RequiredItemName))
            {
               
                //nearInteractableView.Destroy();
                Disable();
                playerView.OnShowHideControls();
                playerView.OnGoTo(nearInteractableView.StartPosition.transform);
                nearInteractableView.StartCoroutine(WaitForApproach());
            }
        }

        private IEnumerator WaitForApproach()
        {
            yield return new WaitUntil(() =>
                Math.Abs(playerView.transform.position.x - (nearInteractableView.StartPosition.transform.position.x)) <
                0.01);
            modeTriggerView.OnMode();
        }

        public void Enable()
        {
            nearInteractableView.TapEvent += OnTap;
        }

        public void Disable()
        {
            nearInteractableView.TapEvent -= OnTap;
        }
    }
}