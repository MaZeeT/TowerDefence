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
    List<GameObject> SpecificSpawnList = new List<GameObject>();

    public bool test;
    public float waveCountdown;

    public bool testScouts = false;
    public bool OverlordSend = false;

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

        waveCountdown = 30f;
    }

    void Update()

    {
        waveCountdown -= Time.deltaTime;

        if (waveCountdown <= 0 && minionsCount == 0) {
            OverlordSend = true;
        }

        if (OverlordSend)
        {
            SpawnScouts();
            SpecificSpawn();
            OverlordSend = false;
        }

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

    void printDamageValueAndTypeOfPath(List<GameObject> path)
    {
        float dpmFire = 0;
        float dpmWater = 0;
        float dpmLightning = 0;
        float dpmPhysical = 0;

        for (int i = 0; i < path.Count; i++)
        {
            switch (path[i].GetComponent<Tower>().getDamageType().ToString())
            {
                case "Fire":
                    dpmFire = dpmFire + path[i].GetComponent<Tower>().getDamagePerMinut();
                    Debug.Log("FIRE DAMAGE INCREASED");

                    break;

                case "Water":
                    dpmWater = dpmWater + path[i].GetComponent<Tower>().getDamagePerMinut();
                    Debug.Log("W DAMAGE INCREASED");

                    break;

                case "Lightning":
                    dpmLightning = dpmLightning + path[i].GetComponent<Tower>().getDamagePerMinut();
                    Debug.Log("L DAMAGE INCREASED");

                    break;

                case "Physical":
                    dpmPhysical = dpmPhysical + path[i].GetComponent<Tower>().getDamagePerMinut();
                    Debug.Log("P DAMAGE INCREASED");

                    break;
            }
        }
        Debug.Log("Fire dmg " + dpmFire);
        Debug.Log("Water dmg " + dpmWater);
        Debug.Log("Lightning dmg " + dpmLightning);
        Debug.Log("Physical dmg " + dpmPhysical);
    }

    void RandomSpawn(int waveSize)
    {
        GetComponent<MinionWaves>().SpawnWave(RandomMinion(), RandomPath(), waveSize);

    }
    void SpecificSpawn() {

        GameObject myKnight = knight, myArcher = archer, myMage = mage;

        myKnight.GetComponent<Health>().setResistanceProfil(100, 100, 100, 100);

        SpecificSpawnList.Add(myKnight);
        SpecificSpawnList.Add(archer);
        SpecificSpawnList.Add(mage);

        GetComponent<MinionWaves>().SpawnSpecificWave(SpecificSpawnList, RandomPath());
    }
    void SpawnScouts()
    {
        // Creates the list of Paths that the SpawnScouts method needs to send 1 scout in each direction. 
        List<GameObject> pathList = new List<GameObject>();
    
        pathList.Add(path1);
        pathList.Add(path2);
        pathList.Add(path3);

        GetComponent<MinionWaves>().SpawnScouts(archer,pathList);
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
        rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0: return knight;
            case 1: return mage;
            case 2: return archer;
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
            else if (path == path2 && !towerListPath1.Contains(list[i]))
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
