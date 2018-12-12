using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    private List<GameObject> towerListPath1;
    private List<GameObject> towerListPath2;
    private List<GameObject> towerListPath3;
    public int testPathNumber;
    public bool printList;

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
        towerListPath1 = new List<GameObject>();
        towerListPath2 = new List<GameObject>();
        towerListPath3 = new List<GameObject>();
    }

    void Update()
    {
        if (test == true)
        {
            RandomSpawn(10);
        }

        if (printList == true)
        {
            if (testPathNumber == 1)
            printListDebug(towerListPath1);
            if (testPathNumber == 2)
                printListDebug(towerListPath2);
            if (testPathNumber == 3)
                printListDebug(towerListPath3);
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

    public void receiveSpotList(List<GameObject> list, GameObject path)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (path == path1 && !towerListPath1.Contains(list[i]))
            {
                towerListPath1.Add(list[i]);
            }
            else if(path == path2 && !towerListPath1.Contains(list[i]))
                {
                    towerListPath2.Add(list[i]);
                }
            else if (path == path3 && !towerListPath1.Contains(list[i]))
            {
                towerListPath3.Add(list[i]);
            }
        }        
    }

    void printListDebug(List<GameObject> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            Debug.Log(path[i].name);
        }
        printList = false;
    }

    public void IncreaseMinionCount()
    {
        this.minionsCount++;
    }

    public void DecreaseMinionCount()
    {
        this.minionsCount--;
    }
}
