using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class PressedReleasedButton : Button
    {

        public event Action PressedEvent;
        public event Action ReleasedEvent;
        
        
        // Button is Pressed
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            PressedEvent?.Invoke();
        }

        // Button is released
        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            ReleasedEvent?.Invoke();
        }
    }
}