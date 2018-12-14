using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionWaves : MonoBehaviour
{
    public GameObject spawner;
    private GameObject path;
    List<GameObject> SpawnList;
    List<GameObject> ScoutSpawnList;

    [Header("Minions")]
    public GameObject knight;
    public GameObject archer;
    public GameObject mage;
    private GameObject minion;

    [Header("Wave Stats")]
    public int waveSize;
    public float delayBetweenMinions;
    

    [Header("ReadOnly Info")]
    public float spawnTime;
    public float countDown;
    public int minionsToSpawn = 0;
    public int minionsAlive;

    public bool isSpawning = false;
    public bool isSpecificSpawning = false;
    public bool isSpawningScout = false;
   

    public void SpawnWave(GameObject minion, GameObject path, int waveSize)
    {

        this.waveSize = waveSize;
        this.minion = minion;
        this.path = path;

        minionsToSpawn = waveSize;
        isSpawning = true;
    }

    public void SpawnSpecificWave(List<GameObject> SpecificSpawnList, GameObject path)
    {
        this.SpawnList = SpecificSpawnList;
        this.path = path;
        countDown = Time.deltaTime;
        isSpecificSpawning = true;
      
        /*
        for (int i = 0; i < SpawnList.Count; i++)
        {
            GameObject minion;
          
            minion = SpawnList[i];
            path = minion.GetComponent<PathFinding>().pathList;
            spawner.GetComponent<Spawner>().Spawn(minion, path);

        }
        */
    }
    public void SpawnScouts(GameObject minion, List<GameObject> ScoutPathList)
    {  //GameObject path1, GameObject path2, GameObject path3) {

        this.ScoutSpawnList = ScoutPathList;
        countDown = Time.deltaTime;
        isSpawningScout = true;

        if (isSpawningScout)
        {
            Debug.Log("Entering For Loop");
            
            for (int i = 0; i < ScoutPathList.Count; )
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                    Debug.Log(countDown);
                spawner.GetComponent<Spawner>().Spawn(minion, ScoutPathList[i]);
                Debug.Log("ScoutsSpawned");
                i++;
            }
            countDown = 10;
        }
    }
    private void Update()
    {
        // Counts down every frame
        countDown -= Time.deltaTime;

        // This is statement checks if the SpawnWave method is running. And ensures that the time between the instantiateion 
        // of each minion is larger than 0, to prevent the creation of mulitiple minions at once. 
        if (isSpawning && countDown <= 0)
        {
            countDown = delayBetweenMinions;
            // Counts down every Minion spawn. 
            if (minionsToSpawn > 0)
            {
                minionsToSpawn--;
                spawner.GetComponent<Spawner>().Spawn(minion, path);
            }
            else if (minionsToSpawn == 0)
            {
                isSpawning = false;
            }
        }
        /*
        if (isSpawningScout && ScoutSpawnList.Count > 0 && countDown <= 0)
        {
            GameObject myScout = archer;

            spawner.GetComponent<Spawner>().Spawn(myScout, ScoutSpawnList[ScoutSpawnList.Count - 1]);
            SpawnList.Remove(ScoutSpawnList[ScoutSpawnList.Count - 1]);


            Debug.Log("ScoutsSpawned");
            countDown = 1;

        }
        */
        if (isSpecificSpawning && SpawnList.Count > 0 && countDown <= 0)
        {
            GameObject minion = SpawnList[SpawnList.Count - 1];
            spawner.GetComponent<Spawner>().Spawn(minion, path);
            SpawnList.Remove(SpawnList[SpawnList.Count - 1]);
            GetComponent<Overlord>().IncreaseMinionCount();

            countDown = 3;

        }
    }
}
