using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackoutScreen : MonoBehaviour
{
    public bool IsDarkeningFinished { get; set; }
    public bool IsLighteningFinished { get; set; }

    private Animator animator;


    public void DarkeningFinished()
    {
       
        IsDarkeningFinished = true;
        IsLighteningFinished = false;
    }

    public void LighteningFinished()
    {
        IsDarkeningFinished = false;
        IsLighteningFinished = true;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        IsDarkeningFinished = false;
    }

    public void StartDarkening()
    {
        animator.SetTrigger("Darkening");
    }

    public void StartLightening()
    {
        animator.SetTrigger("Lightening");
    }
}