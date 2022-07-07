using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackoutScreen : MonoBehaviour
{
 
    
    public event Action DarkeningFinishedEvent;
    public event Action LighteningFinishedEvent;

    private Animator animator;

    public Animator Animator => animator;


    public void DarkeningFinished()
    {
        DarkeningFinishedEvent?.Invoke();
    }
    public void LighteningFinished()
    {
        LighteningFinishedEvent?.Invoke();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
