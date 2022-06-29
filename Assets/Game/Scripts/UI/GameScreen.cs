using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public event Action EnableEvent;

    public void OnEnable()
    {
        EnableEvent?.Invoke();
    }
}
