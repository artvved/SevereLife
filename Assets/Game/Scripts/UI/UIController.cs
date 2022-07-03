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
    void Start()
    {
        blackoutScreen.BlackoutEvent += () =>
        {
            StartCoroutine(Blackout());
        };
        menuScreen.StartGameEvent += () =>
        {
            blackoutScreen.OnBlackout();
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
        OpenScreen(gameScreen.gameObject);
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
