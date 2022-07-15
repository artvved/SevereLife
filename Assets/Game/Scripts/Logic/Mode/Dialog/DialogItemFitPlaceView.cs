using UnityEngine;

namespace Game.Scripts.Logic.Mode.Dialog
{
    public class DialogItemFitPlaceView : MonoBehaviour
    {
        [SerializeField] private ItemName itemName;

        public ItemName ItemName => itemName;
    }
}