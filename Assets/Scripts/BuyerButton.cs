using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyerButton : MonoBehaviour {

    
    public GameManager gameManager;
    public CustomerScript customerScript;
    public int thisNumber;
    public bool _PlayerPressedBuyButton = false;
    public bool notFree;

    // Use this for initialization
    void Start ()
    {
        notFree = true;
     	gameManager = FindObjectOfType<GameManager>();        
    }

	// Update is called once per frame
	void Update ()
    {        
    }

    public void _BuyerButton()
    {
        if (!_PlayerPressedBuyButton)
        {
            if (customerScript.customersAmount < gameManager.playerBaseSugar)
            {
                StartCoroutine("WaitingForButton", 1.0f);
                customerScript.StartCoroutine("DealHappened");
                StopCoroutine("WaitingForButton");
            }
            else
            {

            }            
        }
    }


    IEnumerator WaitingForButton()
    {
        _PlayerPressedBuyButton = true;

        if (customerScript.customersAmount < gameManager.playerBaseSugar)
        {
            notFree = false;
            gameManager.playerBaseMoney += customerScript.customersTotal;
            gameManager.playerBaseSugar -= customerScript.customersAmount;
        }
        yield return new WaitForSeconds(0.1f);   
    }
    
    public int MyNumber(int assignNumber)
    {
        return assignNumber;
    }

    public bool FreeLane()
    {
        return notFree;
    }
}
