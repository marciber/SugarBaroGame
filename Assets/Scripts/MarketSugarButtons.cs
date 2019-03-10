using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MarketSugarButtons : MonoBehaviour
{

    public GameManager gameManager;
    public MarketTradeSys marketTradeSys;
    public UnityEngine.UI.Text itemName;

    public int itemNumber;
    bool waitsec = false;
    public int TotalSugar;

    public WaitForSeconds waitForSecond;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        itemName.text = "" + itemNumber + " Kg";
    }       
   
    public void MarketSugarB()
    {
        if (!waitsec)
        {
            StartCoroutine("WaitingAndProcess", 1.0f);
            Debug.Log("Stage 1 CourutineStarted");
        }
    }

    // between 2 operations the timer wait X seconds 
    IEnumerator WaitingAndProcess()
    {
        waitsec = true;

        if (gameManager.playerBaseMoney >= marketTradeSys.currentSugarPrice * itemNumber)
        {         
            gameManager.playerBaseMoney -= marketTradeSys.currentSugarPrice * itemNumber;
            gameManager.playerBaseSugar += itemNumber;

            TotalSugar = marketTradeSys.currentSugarPrice * itemNumber;

            // Wait few second between 3 buying process
            Debug.Log("TotalSugar : " + TotalSugar);
        }

        yield return new WaitForSeconds(4);
        waitsec = false;
        StopCoroutine("WaitingAndProcess");
    }

}
