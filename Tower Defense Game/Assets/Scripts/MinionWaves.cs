using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionWaves : MonoBehaviour {
    public GameObject spawner;
    private GameObject path;

    [Header ("Minions")]
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
    public bool isSpawning = false;

    public void SpawnWave(List<GameObject> minionWave)
    {
        this.waveSize = minionWave.Count;

        for (int i = 0; i < waveSize; i++)
        {
            GameObject minion = minionWave[i];
            GameObject path = minion.GetComponent<PathFinding>().GetPathList();
            spawner.GetComponent<Spawner>().Spawn(minion, path);
        }
    }

    public void SpawnWave(GameObject minion, GameObject path, int waveSize)
    {
        this.waveSize = waveSize;
        this.minion = minion;
        this.path = path;

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
                spawner.GetComponent<Spawner>().Spawn(minion, path);
            }
            else if (minionsToSpawn == 0)
            {
                isSpawning = false;
            }
        }        
    }
}
