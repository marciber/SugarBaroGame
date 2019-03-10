using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoolDownButton : MonoBehaviour
{

    [System.Serializable]
    public class Transactions
    {
        public float cooldown;
        public Image transactionIcon;
        [HideInInspector]
        public float currentCoolDown;
    }

    public List<Transactions> transaction;


    public void UpdateCoolDown(int number)

    {
        if (transaction[number].currentCoolDown >= transaction[number].cooldown)
        {
            transaction[number].currentCoolDown = 0;
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateCoolDown(0); 
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdateCoolDown(1);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UpdateCoolDown(2);
        }
    }

    void Update()
    {
        foreach (Transactions  t in transaction)
        {
            if (t.currentCoolDown < t.cooldown)
            {
                t.currentCoolDown += Time.deltaTime;
                t.transactionIcon.fillAmount = t.currentCoolDown / t.cooldown;
            }
        }
    }    
 }




   

