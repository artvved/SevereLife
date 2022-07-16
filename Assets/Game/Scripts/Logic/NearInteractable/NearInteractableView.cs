using System;
using Game.Scripts.Logic.Mode;
using UnityEngine;

namespace Game.Scripts.Logic.NearInteractable
{
    public class NearInteractableView : MonoBehaviour,ITapable
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private ItemName requiredItemName;

        public ItemName RequiredItemName => requiredItemName;

        private IModeTriggerView modeTriggerView;
        public Transform StartPosition => startPosition;

        public IModeTriggerView ModeTriggerView => modeTriggerView;

        public event Action TapEvent;
        public void OnTap()
        {
            TapEvent?.Invoke();
        }
        

        private void Awake()
        {
            modeTriggerView = GetComponentInChildren<IModeTriggerView>();
           
        }

        public void Destroy()
        {
            Destroy(this);
        }

        public void ActivateSelf()
        {
            this.enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }

        public void DeactivateSelf()
        {
            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}