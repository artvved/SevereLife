using System;
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


        public void InitItems(InventoryController inventoryController)
        {
            ItemPresenters = new ItemPresenter[itemViews.Length];
          

            for (int i = 0; i < itemViews.Length; i++)
            {
                var view = itemViews[i];
                ItemModel m = new ItemModel(view.ItemName);
                ItemPresenter p = new ItemPresenter(view, m,inventoryController);
                p.Enable();
                ItemPresenters[i] = p;
                
            }
        }

        public void InitReqs()
        {
            RequirementPresenters = new RequirementPresenter[requirementViews.Length];


            for (int i = 0; i < requirementViews.Length; i++)
            {
                var view = requirementViews[i];
                RequirementModel m = new RequirementModel(view.ItemName);
                RequirementPresenter rp = new RequirementPresenter(view, m);
                rp.Enable();
                RequirementPresenters[i] = rp;
            }
        }

        

  
    }
}