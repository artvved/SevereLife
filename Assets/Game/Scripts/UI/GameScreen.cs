using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    [SerializeField] private InventoryController inventoryController;


    public void ShowHideButtons()
    {
        bool activeSelf = buttons.activeSelf;
        buttons.SetActive(!activeSelf);
    }

    public void ShowHideInventory()
    {
        bool activeSelf = inventoryController.gameObject.activeSelf;
        inventoryController.gameObject.SetActive(!activeSelf);
    }
}