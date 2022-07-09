using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class PlayerView : MonoBehaviour,ITapable
{
    private Animator playerAnimator;
    
    public event Action TapEvent;
    public void OnTap()
    {
        TapEvent?.Invoke();
    }

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void Happy()
    {
        playerAnimator.SetTrigger("Happy");
    }
    public void Idle()
    {
        playerAnimator.SetTrigger("Idle");
    }
    public void Walk()
    {
        playerAnimator.SetTrigger("Walk");
    }
}
