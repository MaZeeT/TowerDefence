using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour {

    float initialSpawntime = 30f;

    [Header("Setup")]
    public GameObject spawner;
    public GameObject knight;
    public GameObject archer;
    public GameObject mage;

    [Header("Wave Stats")]
    public int minionsCount;

    void Start()
    {

    }
    
    void Update()
    {
     
    }

    public void IncreaseMinionCount()
    {
        this.minionsCount++;
    }

    public void DecreaseMinionCount()
    {
        this.minionsCount--;
    }

    public void MinionDead(int minionAmount)
    {
    /*    minionsCount -= minionAmount;
        if (minionsCount <= 0 && done)
        {
            spawnTime = initialSpawntime;
            done = false;
        }*/
    }
}
