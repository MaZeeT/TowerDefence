using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    private List<GameObject> towerListPath1;
    private List<GameObject> towerListPath2;
    private List<GameObject> towerListPath3;
    public bool printList;
    public DropDown whichPathToTest;

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
    public float WaveCountDown;

    public enum DropDown
    {   //the different paths to choose from
        path1,
        path2,
        path3
    };

    void Start()
    {
        towerListPath1 = new List<GameObject>();
        towerListPath2 = new List<GameObject>();
        towerListPath3 = new List<GameObject>();
    }

    void Update()
    {
        if (minionsCount <= 0) {
            WaveCountDown -= Time.deltaTime;
            if (WaveCountDown <= 0) {
            test = true;
            }
        }

        if (test == true)
        {
            RandomSpawn(10);
            WaveCountDown = 30f;
            test = false;
        }

        // test for printing objects of list into console depending on which path you wanna know about
        if (printList == true)
        {
            if (whichPathToTest.ToString() == "path1")
            {
                printListDebug(towerListPath1);
                printDamageValueAndTypeOfPath(towerListPath1);
            }

            if (whichPathToTest.ToString() == "path2")
            {
                printListDebug(towerListPath2);
                printDamageValueAndTypeOfPath(towerListPath2);
            }

            if (whichPathToTest.ToString() == "path3")
            {
                printListDebug(towerListPath3);
                printDamageValueAndTypeOfPath(towerListPath3);
            }
        }
    }

    // generate a list of random minions with random paths
    private List<GameObject> generateListToSpawn(int waveSize)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < waveSize; i++)
        {
        // get a random minion
        GameObject minion = RandomMinion();
        // set a random path to minion
        minion.GetComponent<PathFinding>().setPathList(RandomPath());
        // add minion to the listToSpawn
        list.Add(minion);
        }
        return list;
    }

    void printDamageValueAndTypeOfPath(List<GameObject> path)
    {
        float dpmFire = 0.0f;
        float dpmWater = 0.0f;
        float dpmLightning = 0.0f;
        float dpmPhysical = 0.0f;       

        for (int i = 0; i < path.Count; i++)
        {
            switch (path[i].GetComponent<Tower>().getDamageType().ToString())
            {   
                case "fire":
                dpmFire = dpmFire + (float)path[i].GetComponent<Tower>().getDamagePerMinut();
                break;
           
                case "water":       
                dpmWater = dpmWater + (float)path[i].GetComponent<Tower>().getDamagePerMinut();
                break;
               
                case "lightning":
                dpmLightning = dpmLightning + (float)path[i].GetComponent<Tower>().getDamagePerMinut();
                break;
               
                case "physical":
                dpmPhysical = dpmPhysical + (float)path[i].GetComponent<Tower>().getDamagePerMinut();
                break;
            }
        }
        
        Debug.Log("Fire dmg: " + dpmFire);
        Debug.Log("Water dmg: " + dpmWater);
        Debug.Log("Lightning dmg: " + dpmLightning);
        Debug.Log("Physical dmg: " + dpmPhysical);
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
