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
        [SerializeField] private Sprite coin;
        [SerializeField] private Sprite nails;
        [SerializeField] private Sprite carrot;
        [SerializeField] private Sprite bagOfMoney;
        
        

        [Header("Dialog item")]
        [SerializeField] private Sprite dialogGear;
        [SerializeField] private Sprite dialogNails;
        [SerializeField] private Sprite dialogSpoke1;
        [SerializeField] private Sprite dialogSpoke2;
        [SerializeField] private Sprite dialogSpoke3;
        
        [Header("Hints")]
        [SerializeField] private Sprite bladeHint;
        [SerializeField] private Sprite stickHint;
        [SerializeField] private Sprite gearHint;
        [SerializeField] private Sprite carrotHint;
        [SerializeField] private Sprite nailsHint;

        private Dictionary<ItemName, Sprite> inventoryIconsDictionary;
        private Dictionary<ItemName, Sprite> dialogItemsDictionary;
        private Dictionary<ItemName, Sprite> hintSpritesDictionary;
        private void Start()
        {
            inventoryIconsDictionary = new Dictionary<ItemName, Sprite>();
            inventoryIconsDictionary.Add(ItemName.SCYTHE,scythe);
            inventoryIconsDictionary.Add(ItemName.STICK,stick);
            inventoryIconsDictionary.Add(ItemName.BLADE,blade);
            inventoryIconsDictionary.Add(ItemName.WHEAT,wheat);
            inventoryIconsDictionary.Add(ItemName.GEAR,gear);
            inventoryIconsDictionary.Add(ItemName.BAG_OF_WHEAT,bagOfWheat);
            inventoryIconsDictionary.Add(ItemName.COIN,coin);
            inventoryIconsDictionary.Add(ItemName.NAILS,nails);
            inventoryIconsDictionary.Add(ItemName.CARROT,carrot);
            inventoryIconsDictionary.Add(ItemName.BAG_OF_MONEY,bagOfMoney);
            
            dialogItemsDictionary = new Dictionary<ItemName, Sprite>();
            dialogItemsDictionary.Add(ItemName.GEAR,dialogGear);
            dialogItemsDictionary.Add(ItemName.NAILS,dialogNails);
            dialogItemsDictionary.Add(ItemName.SPOKE_1,dialogSpoke1);
            dialogItemsDictionary.Add(ItemName.SPOKE_2,dialogSpoke2);
            dialogItemsDictionary.Add(ItemName.SPOKE_3,dialogSpoke3);
            
            hintSpritesDictionary = new Dictionary<ItemName, Sprite>();
            hintSpritesDictionary.Add(ItemName.GEAR,gearHint);
            hintSpritesDictionary.Add(ItemName.NAILS,nailsHint);
            hintSpritesDictionary.Add(ItemName.BLADE,bladeHint);
            hintSpritesDictionary.Add(ItemName.STICK,stickHint);
            hintSpritesDictionary.Add(ItemName.CARROT,carrotHint);
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


        public Sprite GetHintSpriteByItem(ItemName item)
        {
            Sprite val;
            hintSpritesDictionary.TryGetValue(item, out val);
           
            return val;
        }

    }
}