using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class MarketTradeSys : MonoBehaviour
{
    public UnityEngine.UI.Text TextMarketPriceSugar;
  

    bool priceSugarChange = false;
    

    int maxSugarPrice = 100;
    int minSugarPrice = 5;
    int priceSugarDif;

    public int currentSugarPrice;
    public int nextSugarPrice;
    public int waitingSugarTimePriceChange;      
    float cTime;


    void Start()
        {
            cTime = 0;
            currentSugarPrice = Random.Range(minSugarPrice, maxSugarPrice);
            waitingSugarTimePriceChange = 5;                 
        }
    

    // Update is called once per frame
    void Update()
        {
            cTime += 1 * Time.deltaTime;
        
            if (!priceSugarChange)
            {
                StartCoroutine("SugarPriceGenerator");  
            }
            TextMarketPriceSugar.text = currentSugarPrice + " £ / kg Sugar ";
        }
    
    // Start every process
    IEnumerator StartProcess()
    {
        StartCoroutine("WaitATwoSec", 2.0F);
        yield return new WaitForSeconds(1);
        StopCoroutine("WaitATwoSec");
    }
    

    // This part generate the Random next numbers
    IEnumerator SugarPriceGenerator()
    {
        priceSugarChange = true;   
        nextSugarPrice = Random.Range(minSugarPrice, maxSugarPrice);

        Start:

        if  ( (nextSugarPrice-currentSugarPrice) > 20 || (currentSugarPrice-nextSugarPrice) >= 20 )
        {
            if (nextSugarPrice >= currentSugarPrice)
            {
                for (int i = 0; i < 10; i++)
                {
                    priceSugarDif = nextSugarPrice - currentSugarPrice;
                    currentSugarPrice += (priceSugarDif / 10);
                    yield return new WaitForSeconds(1);
                }
            }
            if (nextSugarPrice < currentSugarPrice)
            {
                for (int i = 0; i < 10; i++)
                {
                    priceSugarDif = currentSugarPrice - nextSugarPrice;
                    currentSugarPrice -= (priceSugarDif / 10);
                    yield return new WaitForSeconds(1);
                }
            }
        }
        else
        {
            nextSugarPrice = Random.Range(minSugarPrice, maxSugarPrice);
            goto Start;
        }

        // Wait 5 second
        yield return new WaitForSeconds(waitingSugarTimePriceChange);        
        priceSugarChange = false;
    }    
}



