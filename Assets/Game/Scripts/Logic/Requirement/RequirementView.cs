using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class RequirementView : MonoBehaviour, ITapable
    {
        [SerializeField] private Animator animator;

        [SerializeField] private ItemName itemName;
        [SerializeField] private GameModeModel gameModeModel;
        [SerializeField] private Transform startPosition;
        [SerializeField] private RequirementView nextInSequence;
        private ItemView rewardItem;

        public ItemName ItemName => itemName;
        public GameModeModel GameModeModel => gameModeModel;

        public Transform StartPosition => startPosition;

        public RequirementView NextInSequence => nextInSequence;

        public ItemModel RewardItemModel;

        public event Action TapEvent;

        public void OnTap()
        {
            TapEvent?.Invoke();
        }

        public event Action DestroyEvent;

        public void OnDestroy()
        {
            DestroyEvent?.Invoke();
        }

        public void ShowRequirement()
        {
            animator.SetTrigger("Show");
        }

        private void Start()
        {
            rewardItem = GetComponentInChildren<ItemView>();
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

        public void ActivateSelf()
        {
            this.enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }
    }
}