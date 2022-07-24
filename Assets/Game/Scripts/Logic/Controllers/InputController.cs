using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using Game.Scripts.Logic.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

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
                    List<ITapable> tapables = new List<ITapable>();
                    tapables.AddRange(hit.collider.gameObject.GetComponentsInChildren<ITapable>());
                    foreach (var tapable in tapables)
                    {
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
}