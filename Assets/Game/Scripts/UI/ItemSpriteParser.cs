using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Logic;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class ItemSpriteParser : MonoBehaviour
    {
        [Header("Inventory Icons")]
        [SerializeField] private Sprite scythe;
        [SerializeField] private Sprite stick;
        [SerializeField] private Sprite blade;
        [SerializeField] private Sprite wheat;
        [SerializeField] private Sprite gear;
        [SerializeField] private Sprite bagOfWheat;
        
        

        [Header("Dialog item")]
        [SerializeField] private Sprite dialogGear;

        private Dictionary<ItemName, Sprite> inventoryIconsDictionary;
        private Dictionary<ItemName, Sprite> dialogItemsDictionary;
        private void Start()
        {
            inventoryIconsDictionary = new Dictionary<ItemName, Sprite>();
            inventoryIconsDictionary.Add(ItemName.SCYTHE,scythe);
            inventoryIconsDictionary.Add(ItemName.STICK,stick);
            inventoryIconsDictionary.Add(ItemName.BLADE,blade);
            inventoryIconsDictionary.Add(ItemName.WHEAT,wheat);
            inventoryIconsDictionary.Add(ItemName.GEAR,gear);
            inventoryIconsDictionary.Add(ItemName.BAG_OF_WHEAT,bagOfWheat);
            
            dialogItemsDictionary = new Dictionary<ItemName, Sprite>();
            dialogItemsDictionary.Add(ItemName.GEAR,dialogGear);
        }

        public ItemName GetItemBySpite(Sprite sprite)
        {
            return inventoryIconsDictionary.FirstOrDefault(x => x.Value.Equals(sprite)).Key;
        }

        public Sprite GetIconByItem(ItemName item)
        {
            Sprite val;
            inventoryIconsDictionary.TryGetValue(item, out val);
            return val;
           
        }
        
        public Sprite GetDialogSpriteByItem(ItemName item)
        {
            Sprite val;
             dialogItemsDictionary.TryGetValue(item, out val);
             return val;
            
        }

    }
}