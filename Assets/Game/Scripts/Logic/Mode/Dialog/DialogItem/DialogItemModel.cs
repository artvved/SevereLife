using System;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Dialog.DialogItem
{
    public class DialogItemModel
    {
        private ItemModel itemModel;
        public DialogItemFitPlaceView PlaceView { get; private set; }
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
            if (!place.Equals(PlaceView))
            {
               //Debug.Log((place.ItemName + " - " + itemModel.ItemName));
                if (place.ItemName.Equals(itemModel.ItemName))
                {
                    isFit = true;
                    PlaceView = place;
                   // Debug.Log("is fit");
                }
            }
        }

        public void UnFit(DialogItemFitPlaceView place)
        {
            if (!place.Equals(PlaceView))
            {

                isFit = false;
                PlaceView = null;
                //Debug.Log("unfit");
            }
        }


        public event Action DestroyEvent;
        public void OnDestroy()
        {
            DestroyEvent?.Invoke();
        }

    }
}