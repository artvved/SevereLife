using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic.Destroy
{
    public class DestroyActionView : QuestAction
    {
        [SerializeField] private ItemView rewardItem;
        
        public ItemModel RewardItemModel;
 
        private void Start()
        {
            if (rewardItem != null)
            {
                RewardItemModel = new ItemModel(rewardItem.ItemName, rewardItem.MergeName, rewardItem.Level);
            }
        }


        public void VisualDestroy()
        {
            StartCoroutine(WaitAndDestroy(1f));
        }
        
        private IEnumerator WaitAndDestroy(float sec)
        {
            //OnDeath();
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            
            for (float i = 0; i < sec; i += Time.deltaTime)
            {
                Color color = spriteRenderer.color;
                color.a = color.a - Time.deltaTime * 255 / 100;
                spriteRenderer.color = color;
                yield return null;
            }

            //yield return new WaitForSeconds(sec);
            //Destroy(gameObject);
        }

    }
}