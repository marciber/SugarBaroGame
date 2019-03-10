using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour {

    public UnityEngine.UI.Text TextCustmSugarAmount;
    public UnityEngine.UI.Text TextCustmSugarPrice;
    public UnityEngine.UI.Text TextCusrmCountDown;
    public UnityEngine.UI.Text TextCusrmTotal;

    public BuyerButton buyerButtonScript;

    public int customersAmount;
    public int customersPrice;
    public int customersTotal;

    int maxAmount = 99;
    int minAmount = 10;

    int minPrice = 60;
    int maxPrice = 150;

    int timeLeftMin = 5;
    int timeLeftMax = 10;
    private static int timeLeft ;

    public bool CustomerActive = false;

    public int TimeLeft
    {
        get
        {
            return timeLeft;
        }

        set
        {
            timeLeft = value;
        }
    }


    // Use this for initialization
    void Start ()
    {        
        CustomerActive = true;
        TimeLeft = Random.Range(timeLeftMin, timeLeftMax);

        // Total amount price
       


        CustmAmountGen();   // Generate random Amount
        TextCustmSugarAmount.text = customersAmount + " Kg";

        
        CustmPriceGen();  // Generate Random Price
        TextCustmSugarPrice.text = "$ "+  customersPrice + "/Kg";
        
       

        customersTotal = (customersAmount * customersPrice);

        TextCusrmTotal.text = "$ " + (customersAmount * customersPrice);

        StartCoroutine("LoseTime");
    }
	
	
	void Update ()
    {
        TextCusrmCountDown.text = (TimeLeft + " Sec Left");

        if (TimeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            StartCoroutine("TimeIsUp");            
        }

        if (buyerButtonScript._PlayerPressedBuyButton == true)
        {
            Debug.Log (" PlayerPressedBuy Button CustScript ");
            StopCoroutine("LoseTime");
            StartCoroutine("DealHappened");
        }
    }

    
    public void CustmAmountGen() // Random Sugar amount generator
    {
        customersAmount = Random.Range(maxAmount, minAmount);
    }

    
    public void CustmPriceGen()  // Random Price generator
    {
        customersPrice = Random.Range(minPrice, maxPrice);
    }    
    
   
    IEnumerator LoseTime()  // Count back - red circle goes down
    {
            while (true)
            {
                yield return new WaitForSeconds(1);
                TimeLeft--;
            }
     }

   
    IEnumerator TimeIsUp()   // count back finnished - no more buy
    {
        TextCusrmCountDown.text = "Run out Time..";
        yield return new WaitForSeconds(1);
        CustomerActive = false;        
        Destroy(gameObject);        
        yield return new WaitForSeconds(0.3f);        
    }

    IEnumerator DealHappened()
    {
        TextCusrmCountDown.text = " DEAL ";
        yield return new WaitForSeconds(1);
        CustomerActive = false;         
        Destroy(gameObject);
        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator WaitOneSeconds()
    {
        yield return new WaitForSeconds(1);
    }    
}
