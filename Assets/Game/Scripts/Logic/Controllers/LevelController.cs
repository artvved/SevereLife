using System;
using Game.Scripts.Logic.Dialog;
using Game.Scripts.Logic.Mode;
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
        [SerializeField]private DialogView[] dialogViews;
        
        [Header("ModeViews")]
        [SerializeField]private CircleTapModeView[] modeViews;
        


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
        
        public void InitDialogs(InventoryController inventoryController)
        {
            for (int i = 0; i < dialogViews.Length; i++)
            {
                var view = dialogViews[i];
                
                DialogPresenter p = new DialogPresenter(view,inventoryController);
                p.Enable();
               
            }
        }
        
        public void InitCircleModes(InventoryController inventoryController,PlayerView playerView,CircleSpawner circleSpawner)
        {
            for (int i = 0; i < modeViews.Length; i++)
            {
                var view = modeViews[i];
                
                CircleTapModePresenter p = new CircleTapModePresenter(view,playerView,inventoryController,circleSpawner);
                p.Enable();
               
            }
        }

        

  
    }
}