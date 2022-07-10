using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using Game.Scripts.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private MenuScreen menuScreen;
    [SerializeField] private GameScreen gameScreen;

    [Header("Blackout")] 
    [SerializeField] private BlackoutScreen blackoutScreen;
    

    [Header("Move buttons")] [SerializeField]
    private PressedReleasedButton leftButton;

    [SerializeField] private PressedReleasedButton rightButton;

    [Header("Entrance button")] [SerializeField]
    private Button entranceButton;

  

    private bool isLighteningFinished;
    private bool isDarkeningFinished;

    void Start()
    {
        
        

        blackoutScreen.DarkeningFinishedEvent += () =>
        {
            isDarkeningFinished = true;
            isLighteningFinished = false;
        };
        blackoutScreen.LighteningFinishedEvent += () =>
        {
            isLighteningFinished = true;
            isDarkeningFinished = false;
        };

        menuScreen.StartGameEvent += () =>
        {
            blackoutScreen.StartDarkening();
            //isLighteningFinished = false;
            StartCoroutine(StartGame());
            
          
        };
        leftButton.PressedEvent += () => { gameController.MoveLeft(); };
        leftButton.ReleasedEvent += () => { gameController.StopMoving(); };
        rightButton.PressedEvent += () => { gameController.MoveRight(); };
        rightButton.ReleasedEvent += () => { gameController.StopMoving(); };

        gameController.ToInside.TriggerEnterEvent += () =>
        {
            entranceButton.gameObject.SetActive(true);
        };
        gameController.ToInside.TriggerExitEvent += () =>
        {
            entranceButton.gameObject.SetActive(false);
        };
        gameController.ToOutside.TriggerEnterEvent += () =>
        {
            entranceButton.gameObject.SetActive(true);
        };

        gameController.ToOutside.TriggerExitEvent += () =>
        {
            entranceButton.gameObject.SetActive(false);
        };
        
    }

    private IEnumerator StartGame()
    {
        yield return new WaitUntil(() => isDarkeningFinished);
        CloseScreen(menuScreen.gameObject);
        gameController.ShowPlayerReq();
        yield return new WaitForSeconds(2);
        OpenScreen(gameScreen.gameObject);
    }

    

    private void OpenScreen(GameObject newScreen)
    {
        newScreen.SetActive(true);
    }

    private void CloseScreen(GameObject oldScreen)
    {
        oldScreen.SetActive(false);
    }

    public void EnterExitHouse()
    {
        blackoutScreen.StartDarkening();
        StartCoroutine(WaitForDarkeningThenEnter());
    }

    private IEnumerator WaitForDarkeningThenEnter()
    {
        yield return new WaitUntil(() => isDarkeningFinished);
        gameController.Enter();
    }
}