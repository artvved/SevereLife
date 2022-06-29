using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackoutScreen : MonoBehaviour
{
 
    
    public event Action BlackoutEvent;

    public void OnBlackout()
    {
        BlackoutEvent?.Invoke();
    }
    
   
}
