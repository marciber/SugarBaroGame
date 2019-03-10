using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    public GameObject gameOverWinPanel, gameOverLosePanel;
    public MarketDiamondButtons marketDiamondButton;
    public GameManager gameManager;

    // Use this for initialization
    void Start ()
    {
        gameOverWinPanel.SetActive(false);
        gameOverLosePanel.SetActive(false);
    }

    void Update()
    {
        if (marketDiamondButton.GotAllTheDiamonds == true)
        {
            gameOverWin();
        }

        if ( gameManager.GameOverYouLose == true)
        {
            gameOverLose();
        }
    }

    public void gameOverWin()
    {
        gameOverWinPanel.SetActive(true);        
    }

    public void gameOverLose()
    {
        gameOverLosePanel.SetActive(true);
        
    }

   
}
