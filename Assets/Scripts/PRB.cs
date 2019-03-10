using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PRB : MonoBehaviour

{
    public CustomerScript CustomerScriptTimer;
    public UnityEngine.UI.Text TimerCountDown;

    public List<GameObject> objectLocation;

    public Transform BuyerInfo;
    public Transform LoadingBar;
    public Transform TextTime;
    public Transform TextSold;
    public Image image;    

    public float currentCoolDown; 

    public float imageFill;
    // public int TimeATM ;
    public int Timer;
   // private int aTimer;
   
   void Start()
    {              
        Timer = CustomerScriptTimer.TimeLeft;       
    }
    
    void Update()
    {       
        if (Timer == 0 )
        {
            Debug.Log("Gone");
            BuyerInfo.gameObject.SetActive(false);               
        }                

        if (currentCoolDown < Timer)
        {
            currentCoolDown +=  Time.deltaTime;
            image.fillAmount = currentCoolDown / Timer;
        }
    }  
}