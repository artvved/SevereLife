using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using Game.Scripts.Logic.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private bool block = false;
    private Camera camera;
    private EventSystem eventSystem;
    private SoundEffect soundEffect;

    private void Start()
    {
        camera = Camera.main;
        eventSystem = EventSystem.current;
        soundEffect = GetComponent<SoundEffect>();
    }

    public void Block()
    {
        block = true;
    }

    public void Unblock()
    {
        block = false;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !eventSystem.IsPointerOverGameObject())
        {
            if (!block)
            {
                RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    
                    
                    var tapable = hit.collider.gameObject.GetComponentInChildren<ITapable>();
                    if (tapable != null)
                    {
                        soundEffect.StartEffect();
                        tapable.OnTap();
                    }
                }
            }
        }
    }
}