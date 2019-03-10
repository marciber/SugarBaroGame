using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public UnityEngine.UI.Text TextPlayerBaseMoney;
    public UnityEngine.UI.Text TextPlayerBaseSugar;
    public UnityEngine.UI.Text TextPlayerBaseDiamond;
    public UnityEngine.UI.Text TextPlayerTargetDiamond;
    public UnityEngine.UI.Text TextTimerCountDown;

    public UnityEngine.UI.Text TotalSugarPrice5;
    public UnityEngine.UI.Text TotalSugarPrice10;
    public UnityEngine.UI.Text TotalSugarPrice30;


    public MarketTradeSys MarketSys;
    public Transform BuyerInfo;
    public MarketDiamondButtons markDiamButt;

    public int playerBaseMoney = 6000;
    public int playerBaseDiamond;
    public int playerBaseSugar;
    public int playerTargetDiamond = 100;

    public float minutes;
    public float seconds;
    public float miliseconds;

    public bool TimerOn = false;
    public bool isPaused = false;
    public bool GameOverYouLose = false;


    // Use this for initialization
    void Start()
    {
        playerBaseDiamond = 0;
        playerBaseSugar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextPlayerBaseMoney.text = "$ "+playerBaseMoney ;
        TextPlayerBaseSugar.text = playerBaseSugar + " Kg";
        TextPlayerBaseDiamond.text = playerBaseDiamond + "";       


        TotalSugarPrice5.text = "$ " + MarketSys.currentSugarPrice * 5;        
        TotalSugarPrice10.text = "$ " + MarketSys.currentSugarPrice * 10;
        TotalSugarPrice30.text = "$ " + MarketSys.currentSugarPrice * 30;

        
        
        if (playerBaseMoney <= 0)
        {
            Debug.LogError("GAME OVER");
        }        

         // Start the timer
        GameTimer();
    }

    public void GameTimer()
    {
        TimerOn = true;

        if (miliseconds <= 0)
        {
            if (seconds <= 0)
            {
                minutes--;
                seconds = 59;
            }
            else if (seconds >= 0)
            {
                seconds--;
            }
            miliseconds = 100;
        }

        miliseconds -= Time.deltaTime * 100;
        
        TextTimerCountDown.text = string.Format("{0}:{1:00}", minutes, seconds);

       
        //Game over if all diamonds collected
        if (markDiamButt.GotAllTheDiamonds == true)
        {            
            TextTimerCountDown.text = " You Win ";
            Time.timeScale = 0;
        }

        //Time Finish - Game Over
        if (seconds==0)
        {
            if (minutes==0)
            {
                TextTimerCountDown.text = "Game Over";
                GameOverYouLose = true;
                Time.timeScale = 0;
            }
        }
    }
}
