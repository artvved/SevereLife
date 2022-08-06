using System;
using Game.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Scripts.Logic.Ads
{
    public class HintView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button leaveButton;
        [SerializeField] private ItemSpriteParser itemSpriteParser;
        [SerializeField] private InventoryController inventoryController;

        private void Awake()
        {
            leaveButton.onClick.AddListener(Hide);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show(ItemName itemName)
        {
            if (itemName == ItemName.SCYTHE)
            {
                if (inventoryController.CheckForItem(ItemName.STICK))
                {
                    itemName = ItemName.BLADE;
                }
                else
                {
                    itemName = ItemName.STICK;
                }
            }

            var sprite = itemSpriteParser.GetHintSpriteByItem(itemName);
            image.sprite = sprite;
            gameObject.SetActive(true);
        }
    }
}