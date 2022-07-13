using System;
using Game.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Logic
{
    public class InventoryController : MonoBehaviour
    {
        //view
        [SerializeField] private Button openButton;
        [SerializeField] private SlotsBarView slotsBar;
        [SerializeField] private SlotView[] slots;
        
        //parser
        [SerializeField] private ItemSpriteParser itemSpriteParser;
        private ItemMerger itemMerger;
        
        //model
        private ItemModel[] items;
        private int firstEmptySlotPointer = 0;
        private bool isOpen = true;
        
        

        private void Start()
        {
            items = new ItemModel[slots.Length];
            itemMerger = new ItemMerger();
        }

        public void AddItem(ItemModel itemModel)
        {
            if (TryMerge(itemModel))
            {
                return;
            }

            items[firstEmptySlotPointer] = itemModel;
            slots[firstEmptySlotPointer].ChangePicture(itemSpriteParser.GetSpriteByItem(itemModel.ItemName));
            firstEmptySlotPointer++;
        }

        private bool TryMerge(ItemModel itemModel)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i]!=null && itemMerger.CanMerge(items[i], itemModel))
                {
                    var newItem=itemMerger.Merge(items[i], itemModel);
                    items[i] = newItem;
                    slots[i].ChangePicture(itemSpriteParser.GetSpriteByItem(newItem.ItemName));
                    return true;
                }
            }

            return false;
        }

        public void ShowHideInventory()
        {
            if (isOpen)
            {
                slotsBar.HideSlots();
            }
            else
            {
                slotsBar.ShowSlots();
            }

            isOpen = !isOpen;
        }

        public bool CheckForItem(ItemName itemName)
        {
            foreach (var item in items)
            {
                if (item!=null && item.ItemName.Equals(itemName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}