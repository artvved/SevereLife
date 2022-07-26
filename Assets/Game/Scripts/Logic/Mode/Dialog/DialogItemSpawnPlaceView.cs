using System;
using Game.Scripts.Logic.Dialog;
using Game.Scripts.Logic.Mode.Dialog.DialogItem;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Dialog
{
    public class DialogItemSpawnPlaceView : MonoBehaviour
    {
        private DialogItemModel defModel;

        public DialogItemModel DefModel => defModel;

        private void Awake()
        {
            var itemView=GetComponentInChildren<ItemView>();
            var dialogItemView=GetComponentInChildren<DialogItemView>();
            if (itemView!=null && dialogItemView)
            {
                ItemModel m = new ItemModel(itemView.ItemName, itemView.MergeName, itemView.Level);
                DialogItemModel model = new DialogItemModel(m);
                DialogItemPresenter presenter = new DialogItemPresenter(model, dialogItemView);
                presenter.Enable();
                defModel = model;
            }
        }
    }
}