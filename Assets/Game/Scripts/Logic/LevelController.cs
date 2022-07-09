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


        private void Start()
        {
            ItemPresenters = new ItemPresenter[itemViews.Length];
            RequirementPresenters = new RequirementPresenter[requirementViews.Length];

            for (int i = 0; i < itemViews.Length; i++)
            {
                var view = itemViews[i];
                ItemModel m = new ItemModel(view.ItemName);
                ItemPresenter p = new ItemPresenter(view, m);
                p.Enable();
                ItemPresenters[i] = p;
                
            }


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