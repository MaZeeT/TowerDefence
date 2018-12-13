using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionWaves : MonoBehaviour {
    public GameObject spawner;
    List<GameObject> minionSpawnList;

    [Header ("Minions")]
    public GameObject knight;
    public GameObject archer;
    public GameObject mage;

    [Header("Wave Stats")]
    public int waveSize;
    public float delayBetweenMinions;

    [Header("ReadOnly Info")]
    public float spawnTime;    
    public float countDown;
    public int minionsToSpawn = 0;        
    public bool isSpawning = false;

    private void Start()
    {
        minionSpawnList = new List<GameObject>();
    }

    public void SpawnWave(GameObject newMinion, GameObject path)
    {
        this.waveSize += 1;
        GameObject minion = newMinion;
        minion.GetComponent<PathFinding>().pathList = path;
        minionSpawnList.Add(minion);
        minionsToSpawn = waveSize;
        isSpawning = true;                            
    }
    private void Update()
    {
        countDown -= Time.deltaTime;
        if (isSpawning && countDown <= 0)
        {
            countDown = delayBetweenMinions;
            if (minionsToSpawn > 0)
            {
                minionsToSpawn--;
                spawner.GetComponent<Spawner>().Spawn(minionSpawnList[minionSpawnList.Count-1]);
                minionSpawnList.Remove(minionSpawnList[minionSpawnList.Count - 1]);
            }
            else if (minionsToSpawn == 0)
            {
                isSpawning = false;
            }
        }        
    }
}
