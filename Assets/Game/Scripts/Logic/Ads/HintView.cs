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
            image.rectTransform.localScale=new Vector3(1,1,1);
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
           
          
            var k=sprite.rect.width / sprite.rect.height;
            
            image.sprite = sprite;
            var sc=image.rectTransform.localScale;
            sc.x *= k;
            image.rectTransform.localScale = sc;
            
            gameObject.SetActive(true);
        }
    }
}