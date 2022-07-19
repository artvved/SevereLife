using System.Collections;
using UnityEngine;

namespace Game.Scripts.Logic.Terrain
{
    public class WaitModePresenter : IPresenter
    {
        private WaitModeView waitModeView;
        private InventoryController inventoryController;
        private PlayerView playerView;
        private ItemModel itemModel;
        private float waitTime;

        public WaitModePresenter(WaitModeView waitModeView, PlayerView playerView,
            InventoryController inventoryController)
        {
            this.waitModeView = waitModeView;
            this.inventoryController = inventoryController;
            this.playerView = playerView;
            waitTime = this.waitModeView.WaitTime;

            if (this.waitModeView.RewardItem != null)
            {
                var v = waitModeView.RewardItem;
                itemModel = new ItemModel(v.ItemName, v.MergeName, v.Level);
            }
        }

        private void OnDoAction()
        {
            waitModeView.StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            waitModeView.StartWaitAnim();
            yield return new WaitForSeconds(waitTime);

            if (itemModel!=null)
            {
                inventoryController.AddItem(itemModel);
            }
            waitModeView.OnNextDoAction();
            playerView.OnShowHideControls();
        }

        public void Enable()
        {
            waitModeView.DoActionEvent += OnDoAction;
        }

        public void Disable()
        {
            waitModeView.DoActionEvent -= OnDoAction;
        }
    }
}