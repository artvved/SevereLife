using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    [SerializeField] private InventoryController inventoryController;


    public void HideButtons()
    {
       
        buttons.SetActive(false);
    }

    public void HideInventory()
    {
        inventoryController.gameObject.SetActive(false);
    }
    
    public void ShowButtons()
    {
       
        buttons.SetActive(true);
    }

    public void ShowInventory()
    {
        inventoryController.gameObject.SetActive(true);
    }
}