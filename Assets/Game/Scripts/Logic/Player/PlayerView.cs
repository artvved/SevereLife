using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class PlayerView : MonoBehaviour,ITapable
{
    private Animator playerAnimator;
    
    public event Action TapEvent;
    public event Action ShowHideControlsEvent;
    public event Action<Transform> GoToEvent; 

    public void OnTap()
    {
        TapEvent?.Invoke();
    }

    public void OnShowHideControls()
    {
        ShowHideControlsEvent?.Invoke();
    }
    
    public void OnGoTo(Transform target)
    {
        GoToEvent?.Invoke(target);
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

    public void Tool()
    {
        playerAnimator.SetTrigger("Tool");
    }

    public void AnimateTranslationToTarget(Transform target)
    {
        StartCoroutine(GoToTarget(target));
    }

    private IEnumerator GoToTarget(Transform target)
    {
        var startPos = transform.position;
        var targetPos = target.position;
        targetPos.y = transform.position.y;
        for (float i = 0; i < 1; i+=Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, i);
            yield return null;
        }

        transform.position = targetPos;
    }


}
