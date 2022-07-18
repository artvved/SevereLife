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
       
        private InventoryController inventoryController;
        private bool isItemRequired;

        public NearInteractablePresenter(NearInteractableView nearInteractableView, PlayerView playerView,
            InventoryController inventoryController)
        {
            this.nearInteractableView = nearInteractableView;
            this.playerView = playerView;
           
            isItemRequired = !this.nearInteractableView.RequiredItemName.Equals(ItemName.NOTHING);
           
            this.inventoryController = inventoryController;
        }

      
        private IEnumerator WaitForApproach()
        {
            yield return new WaitUntil(() =>
                Math.Abs(playerView.transform.position.x - (nearInteractableView.StartPosition.transform.position.x)) <
                0.01);
            nearInteractableView.OnNextDoAction();
           // modeTriggerView.OnMode();
        }

        public void Enable()
        {
            
           
            nearInteractableView.DoActionEvent += OnDoAction;
        }

        public void Disable()
        { 
            
           
            nearInteractableView.DoActionEvent -= OnDoAction;
        }

        private void OnDoAction()
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

                playerView.OnShowHideControls();
                playerView.OnGoTo(nearInteractableView.StartPosition.transform);
                nearInteractableView.StartCoroutine(WaitForApproach());
            }
        }
    }
}