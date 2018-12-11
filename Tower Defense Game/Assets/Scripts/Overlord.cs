using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{

    [Header("Setup")]
    public GameObject spawner;
    public bool test;

    [Header("Minions")]
    public GameObject knight;
    public GameObject archer;
    public GameObject mage;

    [Header("Paths")]
    public GameObject path1;
    public GameObject path2;
    public GameObject path3;

    [Header("Wave Stats")]
    public int minionsCount;

    void Start()
    {

    }

    void Update()
    {
        if (test == true)
        {
            RandomSpawn(10);
        }
    }

    void RandomSpawn(int waveSize)
    {
        GetComponent<MinionWaves>().SpawnWave(RandomMinion(), RandomPath(), waveSize);
    }

    GameObject RandomPath()
    {
        int rand;
        rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0: return path1;
            case 1: return path2;
            case 2: return path3;
        }
        return path3; //Default fallover.
    }

    private GameObject RandomMinion()
    {
        int rand;
        rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0: return knight;
            case 1: return archer;
            case 2: return mage;
        }
        return knight;
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
