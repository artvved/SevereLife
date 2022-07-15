using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.Logic.Dialog
{
    public class DialogItemView : MonoBehaviour, IDragable
    {
        public event Action<PointerEventData> DragEvent;
        public event Action<PointerEventData> DragEndEvent;
        public event Action<Collider2D> TriggerEnterEvent;
        public event Action<Collider2D> TriggerExitEvent;

        private RectTransform rectTransform;
        private Canvas canvas;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            DragEvent?.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DragEndEvent?.Invoke(eventData);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            TriggerExitEvent?.Invoke(other);
        }


        public void Drag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void DragEnd()
        {
            
        }


        public void SetPosition(RectTransform other)
        {
            rectTransform.position = other.position ;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}