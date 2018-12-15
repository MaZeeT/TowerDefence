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
    public bool spawnNextWave;

    [Header("Minions")]
    public GameObject knight;
    public GameObject archer;
    public GameObject mage;

    [Header("Paths")]
    public GameObject path1;
    public GameObject path2;
    public GameObject path3;

    [Header("Wave Stats")]
    public int waveSize;
    public int minionsCount;
    public float timeBetweenWaves;
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
                WaveCountDown = timeBetweenWaves;
                spawnNextWave = true;
            }
        }

        if (spawnNextWave == true)
        {
            // this calls the SpawnWave function in the MinionWave Script
            // where it add the list from generateListToSpawn to the constructur
            GetComponent<MinionWaves>().SpawnWave(addMinionToSpawnList(waveSize));
            spawnNextWave = false;
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
    private List<GameObject> addMinionToSpawnList(int waveSize)
    {
        List<GameObject> list = new List<GameObject>();

        for (int i = 0; i < waveSize; i++)
        {
            GameObject minion = RandomMinion();

            GameObject path = RandomPath();      
            minion.GetComponent<PathFinding>().SetPathList(path);

            minion = generateResistanceProfil(minion);

            // add minion to the listToSpawn
            list.Add(minion);
        }
        return list;
    }

    // this will take a minion, generate and add a random resistProfile to the minion, and lastely return the minion with the new stats 
    private GameObject generateResistanceProfil(GameObject minion)
    {
        int physical = Random.Range(0, 50);
        int fire = Random.Range(0, 50);
        int water = Random.Range(0, 50);
        int lightning = Random.Range(0, 50);
        minion.GetComponent<Health>().setResistanceProfil(physical, fire, water, lightning);
        return minion;
    }

    // function to add information about reporting minions to the storage lists
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

    // return a random minion to caller 
    private GameObject RandomMinion()
    {
        switch (Random.Range(0, 3))
        {
            case 0: return knight;
            case 1: return archer;
            case 2: return mage;
        }
        return knight; //Default fallover
    }

    // return a random path to caller 
    private GameObject RandomPath()
    {
        switch (Random.Range(0, 3))
        {
            case 0: return path1;
            case 1: return path2;
            case 2: return path3;
        }
        return path3; //Default fallover
    }

    // 2 functions to increase or decrease minion count
    public void IncreaseMinionCount()
    {
        this.minionsCount++;
    }

    public void DecreaseMinionCount()
    {
        this.minionsCount--;
    }

    // this is a function to print the list of spotted towers to console depending on which path that is selected in unity
    void printListDebug(List<GameObject> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            Debug.Log(path[i].name);
        }
        printList = false;
    }

    // this is a test function that print and evaluet the amount of damage over time a path will be able to deal 
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
}