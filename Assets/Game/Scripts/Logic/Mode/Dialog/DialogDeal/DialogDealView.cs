using System;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Dialog;
using Game.Scripts.Logic.Mode.Dialog.DialogItem;
using Game.Scripts.Logic.Mode.Move;
using Game.Scripts.Logic.Mode.Quest;
using Game.Scripts.Logic.NearInteractable;
using Game.Scripts.Logic.Sequence;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Logic.Dialog
{
    public class DialogDealView : QuestAction
    {
        [SerializeField] private DialogView dialog;
       
        [SerializeField] private Button agreeButton;
        [SerializeField] private Button disagreeButton;
        
        [SerializeField] private DealView dealView1;
        [SerializeField] private DealView dealView2;
        [SerializeField] private Effect agreeEffect;
        [SerializeField] private Effect disagreeEffect;

        public Button AgreeButton => agreeButton;

        public Button DisagreeButton => disagreeButton;

        public DealView DealView1 => dealView1;

        public DealView DealView2 => dealView2;

        public Effect AgreeEffect => agreeEffect;

        public Effect DisagreeEffect => disagreeEffect;

        public void ShowDialog()
        {
            dialog.gameObject.SetActive(true);
            
            
        }
        public void HideDialog()
        {
            dialog.gameObject.SetActive(false);
            
        }


       
    }
}