using Game.Scripts.Logic.Dialog;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Dialog
{
    [RequireComponent(typeof(Collider2D))]
    public class DialogItemFitPlaceView : MonoBehaviour
    {
        [SerializeField] private ItemName itemName;
        [SerializeField] private bool changeRequiredItem;
        [SerializeField] private ParticleSystem matchEffect;

        public ItemName ItemName => itemName;
        public bool IsFit { get; private set; }

        public void FitComplete(DialogItemView dialogItemView)
        {
            matchEffect.transform.position = transform.position;
            matchEffect.Play();
            if (changeRequiredItem)
            {
                changeRequiredItem = false;
                itemName = ItemName.NAILS;
               // Debug.Log("Fir complete "+itemName+ItemName);
            }
            else
            {
                IsFit = true;
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