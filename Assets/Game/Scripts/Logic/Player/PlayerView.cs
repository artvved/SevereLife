using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using Game.Scripts.Logic.Audio;
using UnityEngine;

public class PlayerView : MonoBehaviour,ITapable
{
    private Animator playerAnimator;
    [SerializeField] private SoundEffect soundEffect;
    
    public event Action TapEvent;
    public event Action HideControlsEvent;
    public event Action ShowControlsEvent;
    public event Action<Transform> GoToEvent; 

    public void OnTap()
    {
        TapEvent?.Invoke();
    }

    public void OnHideControls()
    {
        HideControlsEvent?.Invoke();
    }
    public void OnShowControls()
    {
        ShowControlsEvent?.Invoke();
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
        soundEffect.StopEffect();
        playerAnimator.SetTrigger("Idle");
    }
    public void Walk()
    {
        soundEffect.StartEffect();
        playerAnimator.SetTrigger("Walk");
    }

    public void Tool()
    {
       
        playerAnimator.SetTrigger("Tool");
    }

    public void AnimateTranslationToTarget(Transform target,InputController inputController)
    {
        StartCoroutine(GoToTarget(target,inputController));
    }

    private IEnumerator GoToTarget(Transform target,InputController inputController)
    {
        inputController.Block();
        var startPos = transform.position;
        var targetPos = target.position;
        targetPos.y = transform.position.y;
        for (float i = 0; i < 1; i+=Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, i);
            yield return null;
        }

        transform.position = targetPos;
        Idle();
        inputController.Unblock();
    }

    public event Action<Vector2> TurnEvent; 
    public void OnTurn(Vector2 direction)
    {
        TurnEvent?.Invoke(direction);
    }



}
