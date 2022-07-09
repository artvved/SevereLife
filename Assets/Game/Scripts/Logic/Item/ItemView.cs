using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class ItemView : MonoBehaviour,ITapable
{
    
    [SerializeField] private ItemName itemName;
    public ItemName ItemName => itemName;

    public event Action TapEvent;
    public void OnTap()
    {
        TapEvent?.Invoke();
    }


    public void Destroy()
    {
        Destroy(gameObject);
    }
}
