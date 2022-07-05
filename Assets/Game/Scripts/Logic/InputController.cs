using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<RaycastHit2D> HitEvent;


    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    public void OnHit(RaycastHit2D hit)
    {
        HitEvent?.Invoke(hit);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider!=null)
            {
                OnHit(hit);
            }
            
        }
        
    }
}
