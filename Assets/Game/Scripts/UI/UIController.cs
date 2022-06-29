using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Image image;
    [SerializeField] private float blackoutTime;
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
    }
    
    private IEnumerator Blackout()
    {
        for (float i = 0; i < blackoutTime; i+=Time.deltaTime)
        {
            Color color=image.color;
            color.a =  color.a+Time.deltaTime *255/100;
            image.color = color;
            yield return null;
        }
        CloseScreen(menuScreen.gameObject);
        OpenScreen(gameScreen.gameObject);
        for (float i = 0; i < blackoutTime; i+=Time.deltaTime)
        {
            Color color=image.color;
            color.a =  color.a-Time.deltaTime *255/100;
            image.color = color;
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
