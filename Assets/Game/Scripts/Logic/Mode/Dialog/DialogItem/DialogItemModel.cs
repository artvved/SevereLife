using System;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Dialog.DialogItem
{
    public class DialogItemModel
    {
        private ItemModel itemModel;
        public DialogItemFitPlaceView PlaceView { get; set; }
        public ItemModel ItemModel => itemModel;
        public bool IsFit => isFit;
        

        private bool isFit;

        public DialogItemModel(ItemModel itemModel)
        {
            this.itemModel = itemModel;
            isFit = false;
        }

        public void Fit(DialogItemFitPlaceView place)
        {
            if (place.ItemName.Equals(itemModel.ItemName))
            {
                isFit = true;
                PlaceView = place;
            }
        }

        public void UnFit()
        {
            isFit = false;
            PlaceView = null;
        }


        public event Action DestroyEvent;
        public void OnDestroy()
        {
            DestroyEvent?.Invoke();
        }

    }
}