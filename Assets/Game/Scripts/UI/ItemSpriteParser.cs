using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Logic;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class ItemSpriteParser : MonoBehaviour
    {
        [SerializeField] private Sprite scythe;
        [SerializeField] private Sprite stick;
        [SerializeField] private Sprite blade;
        [SerializeField] private Sprite wheat;
        [SerializeField] private Sprite gear;
        [SerializeField] private Sprite bagOfWheat;


        private Dictionary<ItemName, Sprite> dictionary;
        private void Start()
        {
            dictionary = new Dictionary<ItemName, Sprite>();
            dictionary.Add(ItemName.SCYTHE,scythe);
            dictionary.Add(ItemName.STICK,stick);
            dictionary.Add(ItemName.BLADE,blade);
            dictionary.Add(ItemName.WHEAT,wheat);
            dictionary.Add(ItemName.GEAR,gear);
            dictionary.Add(ItemName.BAG_OF_WHEAT,bagOfWheat);
        }

        public ItemName GetItemBySpite(Sprite sprite)
        {
            return dictionary.FirstOrDefault(x => x.Value.Equals(sprite)).Key;
        }

        public Sprite GetSpriteByItem(ItemName item)
        {
            return dictionary[item];
        }

    }
}