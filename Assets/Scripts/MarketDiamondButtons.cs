using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarketDiamondButtons : MonoBehaviour {

    
    public GameManager gameManager;    
    public MarketTradeSys marketTradeSys;

    public GameObject Diamond_5_Button;
    public GameObject Diamond_10_Button;
    public GameObject Diamond_30_Button;

    public bool Diamond_1_Collected = false;
    public bool Diamond_2_Collected = false;
    public bool Diamond_3_Collected = false;
    public bool GotAllTheDiamonds = false;

    // Use this for initialization
    void Start ()
    {        
        Diamond_5_Button.SetActive(true);
        Diamond_10_Button.SetActive(true);
        Diamond_30_Button.SetActive(true);
        GotAllTheDiamonds = false;
    }

    // Update is called once per frame
    void Update ()
    {
        DiamondsCollected();
    }

    public void Diamond_1_Button()
    {
        if (gameManager.playerBaseMoney >= 5000)
        {
            gameManager.playerBaseMoney -= 5000;
            Diamond_5_Button.SetActive(false);
            Diamond_1_Collected = true;

            if (Diamond_1_Collected == true)
            {
                Debug.Log(" Diamond 1 Check ");
            }           
        }
    }

    public void Diamond_2_Button()
    {
        if (gameManager.playerBaseMoney >= 10000)
        {
            gameManager.playerBaseMoney -= 10000;
            Diamond_10_Button.SetActive(false);
            Diamond_2_Collected = true;

            if (Diamond_2_Collected == true)
            {
                Debug.Log(" Diamond 2 Check ");
            }
        }
    }

    public void Diamond_3_Button()
    {
        if (gameManager.playerBaseMoney >= 30000)
        {
            gameManager.playerBaseMoney -= 30000;
            Diamond_30_Button.SetActive(false);
            Diamond_3_Collected = true;

            if (Diamond_3_Collected == true)
            {
                Debug.Log(" Diamond 3 Check ");
            }
        }
    }

    public void DiamondsCollected()
    {
        if (Diamond_1_Collected == true)
        {
            if (Diamond_2_Collected == true)
            {
                if (Diamond_3_Collected == true)
                {                   
                    GotAllTheDiamonds = true;   
                }
            }
        }
    }    
}
