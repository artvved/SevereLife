using System;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class SlotView : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }


        public void ChangePicture(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
            spriteRenderer.enabled = true;
        }

        public void SetDefaultPicture()
        {
            spriteRenderer.sprite = null;
        }
    }
}