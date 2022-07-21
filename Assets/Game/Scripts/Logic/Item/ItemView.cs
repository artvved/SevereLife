using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using Game.Scripts.Logic.Audio;
using UnityEngine;

public class ItemView : MonoBehaviour,ITapable
{
    
    [SerializeField] private ItemName itemName;
    [SerializeField] private MergeName mergeName;
    [SerializeField] private int level;
    [Header("Sound")]
    [SerializeField] private SoundView soundView;
    public ItemName ItemName => itemName;
    public MergeName MergeName => mergeName;

    public int Level => level;

    public event Action TapEvent;
    public void OnTap()
    {
        TapEvent?.Invoke();
    }


    public void DeactivateAndHide()
    {
        var c = GetComponent<Collider2D>();
        c.enabled = false;
        var vis = GetComponentInChildren<SpriteRenderer>();
        vis.enabled = false;
        soundView.Play();
       
    }
}
