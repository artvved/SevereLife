using Game.Scripts.Logic.Dialog;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.Logic.Mode.Dialog.DialogItem
{
    public class DialogItemPresenter : IPresenter
    {
        private DialogItemModel dialogItemModel;
        private DialogItemView dialogItemView;

        public DialogItemPresenter(DialogItemModel dialogItemModel, DialogItemView dialogItemView)
        {
            this.dialogItemModel = dialogItemModel;
            this.dialogItemView = dialogItemView;
        }

        public void Enable()
        {
            dialogItemView.DragEvent += OnDrag;
            dialogItemView.DragEndEvent += OnEndDrag;
            dialogItemView.TriggerEnterEvent += OnTriggerEnter;
            dialogItemView.TriggerExitEvent += OnTriggerExit;

            dialogItemModel.DestroyEvent += OnDestroy;
        }

        public void Disable()
        {
            dialogItemView.DragEvent -= OnDrag;
            dialogItemView.DragEndEvent -= OnEndDrag;
            dialogItemView.TriggerEnterEvent -= OnTriggerEnter;
            dialogItemView.TriggerExitEvent -= OnTriggerExit;
            
            dialogItemModel.DestroyEvent -= OnDestroy;
        }

        private void OnEndDrag(PointerEventData eventData)
        {
          
          
            if (dialogItemModel.IsFit)
            {
                dialogItemView.SetPosition(dialogItemModel.PlaceView.GetComponent<RectTransform>());
                if ( dialogItemModel.PlaceView!=null)
                {
                    dialogItemModel.PlaceView.FitComplete(dialogItemView);
                }
                Disable();
            }
        }

        private void OnDrag(PointerEventData eventData)
        {
            dialogItemView.Drag(eventData);
        }

        private void OnTriggerEnter(Collider2D other)
        {
           
            var place = other.gameObject.GetComponent<DialogItemFitPlaceView>();
            
            if (place!=null)
            {
                dialogItemModel.Fit(place);
            }
          
         
        }

        private void OnTriggerExit(Collider2D other)
        { 
            var place = other.gameObject.GetComponent<DialogItemFitPlaceView>();
           
            if (place!=null)
            {
                dialogItemModel.UnFit(place);
            }
            
        }


        private void OnDestroy()
        {
            Disable();
            dialogItemView.Destroy();
           
            
            dialogItemModel = null;
        }
    }
}