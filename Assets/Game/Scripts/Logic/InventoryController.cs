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
        
        //model
        private ItemName[] items;
        private int firstEmptySlotPointer = 0;
        private bool isOpen = true;

        private void Start()
        {
            items = new ItemName[slots.Length];
        }

        public void AddItem(ItemName name)
        {
            items[firstEmptySlotPointer] = name;
            slots[firstEmptySlotPointer].ChangePicture(itemSpriteParser.GetSpriteByItem(name));
            firstEmptySlotPointer++;
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
    }
}