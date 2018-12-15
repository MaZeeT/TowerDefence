using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionWaves : MonoBehaviour {
    public GameObject spawner;
    private GameObject path;
    private GameObject minion;
    private List<GameObject> minionList;
    public float delayBetweenMinions;

    [Header("ReadOnly Info")]
    public float countDown;
    public int minionsToSpawn = 0;        
    public bool isSpawning = false;
    private int i;

    public void SpawnWave(List<GameObject> minionList)
    {
        this.minionList = minionList;
        this.minionsToSpawn = minionList.Count;
        isSpawning = true;
    }

    public void SpawnWave(GameObject minion, GameObject path, int waveSize)
    {
        this.minion = minion;
        this.path = path;
        this.minionsToSpawn = waveSize;
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
                minion = minionList[i];
                path = minion.GetComponent<PathFinding>().GetPathList();
                spawner.GetComponent<Spawner>().Spawn(minion, path);

                i++;    //will spawn next minion in the list
            }
            else if (minionsToSpawn == 0)
            {
                isSpawning = false;
                i = 0;
            }
        }        
    }
}
