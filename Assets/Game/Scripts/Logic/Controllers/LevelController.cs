using System;
using Game.Scripts.Logic.Dialog;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.NearInteractable;
using Game.Scripts.Logic.Terrain;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class LevelController : MonoBehaviour
    {
        [Header("Items")] 
        [SerializeField] private ItemView[] itemViews;
        public ItemPresenter[] ItemPresenters;

        [Header("Requirements")]
        [SerializeField]private RequirementView[] requirementViews;
        public RequirementPresenter[] RequirementPresenters;
        
        [Header("Dialogs")]
        [SerializeField]private DialogTriggerView[] dialogViews;
        
        [Header("ModeViews")]
        [SerializeField]private CircleTapModeTriggerView[] modeViews;
        
        [Header("NearInteractableViews")]
        [SerializeField]private NearInteractableView[] nearInteractableViews;

        [SerializeField] private WaitModeView waitModeView;
        


        public void InitItems(InventoryController inventoryController)
        {
            ItemPresenters = new ItemPresenter[itemViews.Length];
          

            for (int i = 0; i < itemViews.Length; i++)
            {
                var view = itemViews[i];
                ItemModel m = new ItemModel(view.ItemName,view.MergeName,view.Level);
                ItemPresenter p = new ItemPresenter(view, m,inventoryController);
                p.Enable();
                ItemPresenters[i] = p;
                
            }
        }

        public void InitReqs(InventoryController inventoryController)
        {
            RequirementPresenters = new RequirementPresenter[requirementViews.Length];


            for (int i = 0; i < requirementViews.Length; i++)
            {
                var view = requirementViews[i];
                RequirementModel m = new RequirementModel(view.ItemName);
                RequirementPresenter rp = new RequirementPresenter(view, m,inventoryController);
                rp.Enable();
                RequirementPresenters[i] = rp;
            }
        }
        
        public void InitDialogTriggers(InventoryController inventoryController,PlayerView playerView)
        {
            for (int i = 0; i < dialogViews.Length; i++)
            {
                var view = dialogViews[i];
                
                DialogTriggerPresenter p = new DialogTriggerPresenter(view,inventoryController,playerView);
                p.Enable();
               
            }
        }
        
        public void InitCircleModes(InventoryController inventoryController,CircleSpawner circleSpawner)
        {
            for (int i = 0; i < modeViews.Length; i++)
            {
                var view = modeViews[i];
                
                CircleTapModeTriggerPresenter p = new CircleTapModeTriggerPresenter(view,inventoryController,circleSpawner);
                p.Enable();
               
            }
        }
        
        public void InitNearInteractableViews(PlayerView playerView,InventoryController inventoryController)
        {
            for (int i = 0; i < nearInteractableViews.Length; i++)
            {
                var view = nearInteractableViews[i];
               
                NearInteractablePresenter p = new NearInteractablePresenter(view,playerView,inventoryController);
                p.Enable();
               
            }
        }

        public void InitWind(PlayerView playerView,InventoryController inventoryController)
        {
            var view = waitModeView;
               
            WaitModePresenter p = new WaitModePresenter(view,playerView,inventoryController);
            p.Enable();
        }




    }
}