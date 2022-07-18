using System;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic.NearInteractable
{
    public class NearInteractableView : QuestAction
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private ItemName requiredItemName;

        public ItemName RequiredItemName => requiredItemName;

       
        public Transform StartPosition => startPosition;

        

      

       

        public void Destroy()
        {
            Destroy(this);
        }

       

        //
    }
}