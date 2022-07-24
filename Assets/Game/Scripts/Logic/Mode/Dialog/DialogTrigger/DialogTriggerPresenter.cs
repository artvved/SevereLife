using System.Collections.Generic;
using Game.Scripts.Logic.Mode.Dialog;
using Game.Scripts.Logic.Mode.Dialog.DialogItem;
using Game.Scripts.Logic.NearInteractable;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Logic.Dialog
{
    public class DialogTriggerPresenter : IPresenter
    {
        private DialogTriggerView dialogTriggerView;
        private InventoryController inventoryController;
        private PlayerView playerView;

        private DialogItemSpawnPlaceView[] places;
        private Button leaveButton;
       

        private List<DialogItemModel> dialogItemModels;

        public DialogTriggerPresenter(DialogTriggerView dialogTriggerView, InventoryController inventoryController,
            PlayerView playerView)
        {
            this.dialogTriggerView = dialogTriggerView;
            this.inventoryController = inventoryController;
            this.playerView = playerView;
            this.places = dialogTriggerView.Places;
            leaveButton = dialogTriggerView.LeaveButton;
            dialogItemModels = new List<DialogItemModel>();
           
        }

        


        private void DestroyItemModels()
        {
            for (int i = 0; i < dialogItemModels.Count; i++)
            {
                dialogItemModels[i].OnDestroy();
            }

            dialogItemModels = new List<DialogItemModel>();
        }

        private bool IsDialogComplete()
        {
         
            if (dialogItemModels.Count == 0)
            {
                return false;
            }

            foreach (var m in dialogItemModels)
            {
                if (!m.IsFit)
                {
                    return false;
                }
            }

            return true;
        }


        private void OnLeave()
        {
           
            if (IsDialogComplete())
            {
                for (int i = 0; i < dialogItemModels.Count; i++)
                {
                    inventoryController.RemoveItem(dialogItemModels[i].ItemModel);
                }

                DestroyItemModels();
                dialogTriggerView.HideDialog();
                playerView.OnShowControls();
                dialogTriggerView.OnNext();
                return;
            }

            DestroyItemModels();
            dialogTriggerView.HideDialog();
            playerView.OnShowControls();
            
            dialogTriggerView.OnBack();
            
           
        }

        public void Enable()
        {
           
            leaveButton.onClick.AddListener(OnLeave);
            
            dialogTriggerView.DoActionEvent += OnDoAction;
        }

        public void Disable()
        {
           
            leaveButton.onClick.RemoveAllListeners();
            
        }

        private void OnDoAction()
        {
            dialogTriggerView.ShowDialog();
            //spawn items
            var items = inventoryController.Items;
            for (int i = 0; i < items.Length; i++)
            {
                var m = items[i];
                var sprite = inventoryController.GetDialogItemSprite(m);
                if (sprite != null)
                {
                    DialogItemModel model = new DialogItemModel(m);
                    var view = dialogTriggerView.CreateDialogItem(places[i].transform);
                    DialogItemPresenter presenter = new DialogItemPresenter(model, view);
                    presenter.Enable();

                    dialogItemModels.Add(model);
                }
            }
        }


    }
}