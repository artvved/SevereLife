using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Logic.Dialog
{
    public class DialogView : MonoBehaviour, ITapable
    {
        [SerializeField] private GameObject dialog;
        [SerializeField] private Button leaveButton;

        public event Action TapEvent;

        public void OnTap()
        {
            TapEvent?.Invoke();
        }


        public void ShowDialog()
        {
            dialog.SetActive(true);
            leaveButton.gameObject.SetActive(true);
        }
        public void HideDialog()
        {
            dialog.SetActive(false);
            leaveButton.gameObject.SetActive(false);
        }
    }
}