using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public event Action EnableEvent;
    [SerializeField] private GameObject buttons;

    public void OnEnable()
    {
        EnableEvent?.Invoke();
    }

    public void ShowHideButtons()
    {
        bool activeSelf=buttons.activeSelf;
        buttons.SetActive(!activeSelf);
    }
}
