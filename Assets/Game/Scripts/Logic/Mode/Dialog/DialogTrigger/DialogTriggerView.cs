using System;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Dialog;
using Game.Scripts.Logic.Mode.Dialog.DialogItem;
using Game.Scripts.Logic.Mode.Quest;
using Game.Scripts.Logic.NearInteractable;
using Game.Scripts.Logic.Sequence;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Logic.Dialog
{
    public class DialogTriggerView : QuestAction
    {
        [SerializeField] private DialogView dialog;
        [SerializeField] private DialogItemSpawnPlaceView[] places;
        [SerializeField] private DialogItemFitPlaceView[] fitPlaces;
        [SerializeField] private Button leaveButton;
        [SerializeField] private DialogItemView prefab;


        public DialogItemFitPlaceView[] FitPlaces => fitPlaces;

        public DialogItemSpawnPlaceView[] Places => places;

        public Button LeaveButton => leaveButton;
        

       
        

        public void ShowDialog()
        {
            dialog.gameObject.SetActive(true);
            
            
        }
        public void HideDialog()
        {
            dialog.gameObject.SetActive(false);
            
        }

        public DialogItemView CreateDialogItem(Transform place,Sprite sprite)
        {
            var res= Instantiate(prefab, place);
            res.GetComponentInChildren<Image>().sprite = sprite;
            return res;
        }

        
    }
}