using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Image blackoutImage;
    [SerializeField] private float blackoutTime;
    
    [Header("Move buttons")]
    [SerializeField] private PressedReleasedButton leftButton;
    [SerializeField] private PressedReleasedButton rightButton;

    private bool isCutscene;
    void Start()
    {
        blackoutScreen.BlackoutEvent += () =>
        {
            StartCoroutine(Blackout());
            isCutscene = true;
        };
        menuScreen.StartGameEvent += () =>
        {
            blackoutScreen.OnBlackout();
            
            StartCoroutine(StartGame());
            
        };
        leftButton.PressedEvent += () =>
        {
            gameController.MoveLeft();
        };
        leftButton.ReleasedEvent += () =>
        {
            gameController.StopMoving();
        };
        rightButton.PressedEvent += () =>
        {
            gameController.MoveRight();
        };
        rightButton.ReleasedEvent += () =>
        {
            gameController.StopMoving();
        };
    }

    private IEnumerator StartGame()
    {
        gameController.ShowPlayerReq();
        yield return new WaitForSeconds(3);
        OpenScreen(gameScreen.gameObject);
        //yield return new WaitUntil(() => !isCutscene);

    }

    private IEnumerator Blackout()
    {
        for (float i = 0; i < blackoutTime; i+=Time.deltaTime)
        {
            Color color=blackoutImage.color;
            color.a =  color.a+Time.deltaTime *255/100;
            blackoutImage.color = color;
            yield return null;
        }
        CloseScreen(menuScreen.gameObject);
       
        for (float i = 0; i < blackoutTime; i+=Time.deltaTime)
        {
            Color color=blackoutImage.color;
            color.a =  color.a-Time.deltaTime *255/100;
            blackoutImage.color = color;
            yield return null;
        }

        
    }

   

    private void OpenScreen(GameObject newScreen)
    {
        newScreen.SetActive(true);
    }
    private void CloseScreen(GameObject oldScreen)
    {
        oldScreen.SetActive(false);
        
    }
}
