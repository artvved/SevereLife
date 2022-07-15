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

        public ItemModel[] Items => items;


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
            slots[firstEmptySlotPointer].ChangePicture(itemSpriteParser.GetIconByItem(itemModel.ItemName));
            firstEmptySlotPointer++;
        }

        public void RemoveItem(ItemModel itemModel)
        {
            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (itemModel.Equals(items[i]))
                {
                    items[i] = null;
                    slots[i].SetDefaultPicture();
                    firstEmptySlotPointer = i;
                }
            }
            
        }

        private bool TryMerge(ItemModel itemModel)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i]!=null && itemMerger.CanMerge(items[i], itemModel))
                {
                    var newItem=itemMerger.Merge(items[i], itemModel);
                    items[i] = newItem;
                    slots[i].ChangePicture(itemSpriteParser.GetIconByItem(newItem.ItemName));
                    return true;
                }
            }

            return false;
        }

        public Sprite GetDialogItemSprite(ItemModel model)
        {
            if (model==null)
            {
                return null;
            }
            return itemSpriteParser.GetDialogSpriteByItem(model.ItemName);
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