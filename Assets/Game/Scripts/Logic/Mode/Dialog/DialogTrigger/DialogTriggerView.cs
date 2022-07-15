using System;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Dialog;
using Game.Scripts.Logic.Mode.Dialog.DialogItem;
using Game.Scripts.Logic.NearInteractable;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Logic.Dialog
{
    public class DialogTriggerView : MonoBehaviour,IModeTriggerView
    {
        [SerializeField] private DialogView dialog;
        [SerializeField] private DialogItemSpawnPlaceView[] places;
        [SerializeField] private Button leaveButton;
        [SerializeField] private DialogItemView prefab;


        public DialogItemSpawnPlaceView[] Places => places;

        public Button LeaveButton => leaveButton;
        private NearInteractableView nearInteractableView;

        public NearInteractableView NearInteractableView => nearInteractableView;

        public event Action ModeEvent;

        public void OnMode()
        {
            ModeEvent?.Invoke();
        }

        private void Awake()
        {
            nearInteractableView = GetComponent<NearInteractableView>();
        }

        public void ShowDialog()
        {
            dialog.gameObject.SetActive(true);
            
            
        }
        public void HideDialog()
        {
            dialog.gameObject.SetActive(false);
            
        }

        public DialogItemView CreateDialogItem(Transform parent)
        {
            return Instantiate(prefab, parent);
        }

        public void Destroy()
        {
            Destroy(this);
        }


    }
}