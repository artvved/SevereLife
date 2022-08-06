using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic.Mode.Dialog;
using Game.Scripts.Logic.Mode.Dialog.DialogItem;
using Game.Scripts.Logic.NearInteractable;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Logic.Dialog
{
    public class DialogDealPresenter : IPresenter
    {
        private DialogDealView view;
        private InventoryController inventoryController;

        private PlayerView playerView;
        private Button agreeButton;
        private Button disagreeButton;
       

       

        public DialogDealPresenter(DialogDealView view,PlayerView playerView, InventoryController inventoryController)
        {
            this.view = view;
            this.inventoryController = inventoryController;
            this.playerView = playerView;
           
            agreeButton = this.view.AgreeButton;
            disagreeButton= this.view.DisagreeButton;
        }

        

        private void Agree()
        {
            view.AgreeEffect.StartEffect();
            if (view.DealView1.IsActive)
            {
                view.DealView1.PlaySound();
                for (int i = 0; i < 3; i++)
                {
                    inventoryController.AddItem(new ItemModel(ItemName.COIN,MergeName.NOTHING,0));
                }
                inventoryController.RemoveItem(ItemName.BAG_OF_WHEAT);
                view.HideDialog();
                view.NextDoAction();
                
            }
            else
            {
                view.DealView2.PlaySound();
                for (int i = 0; i < 3; i++)
                {
                    inventoryController.AddItem(new ItemModel(ItemName.COIN,MergeName.NOTHING,0));
                }
                inventoryController.AddItem(new ItemModel(ItemName.BAG_OF_MONEY,MergeName.NOTHING,0));
                inventoryController.RemoveItem(ItemName.BAG_OF_WHEAT);
                view.HideDialog();
                view.NextDoAction();
            }
        }
        private void Disagree()
        {
            view.DisagreeEffect.StartEffect();
            if (view.DealView1.IsActive)
            {
                view.StartCoroutine(DisagreeAnimation());
                
            }
            else
            {
                
                view.DealView1.ToIdle();
                view.DealView2.ToIdle();
                
                view.HideDialog();
                view.OnBack();
                playerView.OnShowControls();
            }
        }

        private IEnumerator DisagreeAnimation()
        {
            Disable();
            view.DealView1.HideDeal();
            yield return new WaitUntil(()=>!view.DealView1.IsActive);
            view.DealView2.ShowDeal();
            yield return new WaitUntil(()=>view.DealView2.IsActive);
            Enable();
        }


        public void Enable()
        {
            agreeButton.onClick.AddListener(Agree);
            disagreeButton.onClick.AddListener(Disagree);
            view.DoActionEvent += ShowDialog;
        }

        public void Disable()
        {
            agreeButton.onClick.RemoveAllListeners();
            disagreeButton.onClick.RemoveAllListeners();
            view.DoActionEvent -= ShowDialog;
        }

        private void ShowDialog()
        {
            view.ShowDialog();
            
            
            
            
        }


    }
}