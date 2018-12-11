using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionWaves : MonoBehaviour {
    public GameObject spawner;
    public GameObject path;

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

    void SpawnWave(int waveSize)
    {
        this.waveSize = waveSize;
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
                spawner.GetComponent<Spawner>().Spawn(knight, path);
            }
            else if (minionsToSpawn == 0)
            {
                isSpawning = false;
            }
        }        
    }
}
