using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameover=false;
    public GameObject gamepanel;
    public static bool IsGameStarted;
    public GameObject startingText;
    public static int numberofCoins;
    public Text cointxt;

    void Start()
    {
        gameover = false;
        IsGameStarted = false;
        Time.timeScale = 1;
        numberofCoins = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
       if (gameover==true)
        {
            Time.timeScale = 0;
            gamepanel.SetActive(true);
            
        } 

       if((SwipeManager.swipeUp)|| (SwipeManager.swipeDown)|| (SwipeManager.swipeLeft)||(SwipeManager.swipeRight))
        {
            IsGameStarted = true;
            Destroy(startingText);
        }
        cointxt.text = "Coins:" + numberofCoins;
        
    }
}
