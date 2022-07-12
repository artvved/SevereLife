using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class ItemView : MonoBehaviour,ITapable
{
    
    [SerializeField] private ItemName itemName;
    [SerializeField] private MergeName mergeName;
    [SerializeField] private int level;
    public ItemName ItemName => itemName;
    public MergeName MergeName => mergeName;

    public int Level => level;

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
