using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool block = false;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
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
        if (Input.GetMouseButtonDown(0))
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
                            tapable.OnTap();
                        }
                    }
                }
            }
        }
    }
}