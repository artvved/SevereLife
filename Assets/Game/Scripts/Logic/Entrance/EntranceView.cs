using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceView : MonoBehaviour
{
    [SerializeField] private GameObject[] toEnable;
    [SerializeField] private GameObject[] toDisable;
    [SerializeField] private Transform spawnPoint;

    public GameObject[] ToEnable => toEnable;

    public GameObject[] ToDisable => toDisable;

    public Transform SpawnPoint => spawnPoint;

    public event Action TriggerEnterEvent;
    public event Action TriggerExitEvent;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        TriggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TriggerExitEvent?.Invoke();
    }
}
