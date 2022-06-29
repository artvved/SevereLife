using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public event Action StartGameEvent;

    public void OnStartGame()
    {
        StartGameEvent?.Invoke();
    }
}
