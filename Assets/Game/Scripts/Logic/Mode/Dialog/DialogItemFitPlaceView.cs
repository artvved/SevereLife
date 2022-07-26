using Game.Scripts.Logic.Dialog;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Dialog
{
    [RequireComponent(typeof(Collider2D))]
    public class DialogItemFitPlaceView : MonoBehaviour
    {
        [SerializeField] private ItemName itemName;
        [SerializeField] private bool changeRequiredItem;

        public ItemName ItemName => itemName;

        public void FitComplete(DialogItemView dialogItemView)
        {
            if (changeRequiredItem)
            {
                changeRequiredItem = false;
                itemName = ItemName.NAILS;
                Debug.Log("Fir complete "+itemName+ItemName);
            }
            else
            {
                Collider2D col = GetComponent<Collider2D>();
                col.enabled = false;
                if (ItemName.Equals(ItemName.NAILS))
                {
                   dialogItemView.Hide();
                }
            }
           
        }
    }
}