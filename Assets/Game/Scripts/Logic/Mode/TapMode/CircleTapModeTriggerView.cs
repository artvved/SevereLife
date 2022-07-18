using System;
using System.Collections;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class CircleTapModeTriggerView : QuestAction
    {
        [SerializeField] private int circlesCount;
        
       
        
        [SerializeField] private ItemView rewardItem;
        
        public ItemModel RewardItemModel;

        public int CirclesCount => circlesCount;

      
      
        
        
        private void Start()
        {
            if (rewardItem != null)
            {
                RewardItemModel = new ItemModel(rewardItem.ItemName, rewardItem.MergeName, rewardItem.Level);
            }
        }
        
       

        public void Destroy()
        {
            StartCoroutine(WaitAndDestroy(1f));
        }
        
        private IEnumerator WaitAndDestroy(float sec)
        {
            OnDeath();
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            
            for (float i = 0; i < sec; i += Time.deltaTime)
            {
                Color color = spriteRenderer.color;
                color.a = color.a - Time.deltaTime * 255 / 100;
                spriteRenderer.color = color;
                yield return null;
            }

            //yield return new WaitForSeconds(sec);
            Destroy(gameObject);
        }
        
        
      

       
        public event Action DeathEvent;

        private void OnDeath()
        {
            DeathEvent?.Invoke();
        }

        
    }
}