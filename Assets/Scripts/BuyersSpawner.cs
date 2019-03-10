using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyersSpawner : MonoBehaviour {
    public CustomerScript customerScript;
    public GameManager gameManager;

    public RectTransform buyerInfos;

    public Transform BuyersPrefab;
    public Transform BuyerParentPlace;

    public GameObject BuyerFolder;
    public GameObject lastSpawned;
    public RectTransform[] SpawnPoints;
    public bool[] isTaken;
    public BuyerButton[] AllButtons;
    public float[] freeLaneTime;


    float spawnWait = 5;
    float lastRand;
    public float spawnBuyerMin = 0;
    public float spawnBuyerMax = 5;
    public float startWait;

    // Use this for initialization
    void Start ()
    {
        freeLaneTime = new float[5];
        for (int i = 0; i < freeLaneTime.Length; i++)
        {
            freeLaneTime[i] = 0;
        }
       
        isTaken = new bool[5];
        AllButtons = new BuyerButton[SpawnPoints.Length];
        for (int i = 0; i < isTaken.Length; i++)
        {
            isTaken[i] = false;
        }
    }

	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.TimerOn == true)
        {
            spawnWait += Time.deltaTime;
            for (int i = 0; i < freeLaneTime.Length; i++)
            {
                freeLaneTime[i] += Time.deltaTime;
            }

            int rand = Random.Range(0, 4);

            float xComp = SpawnPoints[rand].position.x;
            float yComp = SpawnPoints[rand].position.y;
            float zComp = SpawnPoints[rand].position.z;

            Vector3 finalVector = new Vector3(xComp, yComp, zComp);

            if (spawnWait > 11 && isTaken[rand] == false)
            {
                spawnWait = 0;
                lastSpawned = Instantiate(BuyersPrefab.gameObject, finalVector, Quaternion.identity, buyerInfos);

                isTaken[rand] = true;
                AllButtons[rand] = lastSpawned.GetComponent<BuyerButton>();
            }
            for (int i = 0; i < isTaken.Length; i++)
            {
                if (isTaken[i])
                {
                    freeLaneTime[i] += Time.deltaTime;
                    if (freeLaneTime[i] > 11)
                    {
                        isTaken[i] = false;
                    }
                }
            }
        }
    }
    IEnumerator WaitOneSeconds()
    {
        yield return new WaitForSeconds(1);
    }
}
