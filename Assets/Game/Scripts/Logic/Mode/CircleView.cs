using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.Logic.Mode
{
    public class CircleView: MonoBehaviour,ITapable
    {
        [SerializeField] private Sprite completeSprite;
        private SpriteRenderer spriteRenderer;
        
        
        
        public event Action TapEvent;

        public void OnTap()
        {
            TapEvent?.Invoke();
        }


        public void Die()
        {
            spriteRenderer.sprite = completeSprite;
            StartCoroutine(AnimateAndDie());

        }

       

        private IEnumerator AnimateAndDie()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }

        private void Start()
        {
           spriteRenderer= GetComponent<SpriteRenderer>();
        }
    }
}