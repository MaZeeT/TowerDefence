using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {
    public float spawnTime = 30f;
    public int minionCount = 0;
    GameObject Overlord, Warrior, enemySpawn;
    Vector3 enemySpawnPoint;
    float initialCount = 4f;
    public float count;
    bool spawning = false, done = false;

    // Use this for initialization
    void Start () {
        Overlord = GameObject.FindGameObjectWithTag("Overload");
        Warrior = GameObject.FindGameObjectWithTag("Enemy");
        enemySpawn = GameObject.FindGameObjectWithTag("EnemySpawn");
        enemySpawnPoint = enemySpawn.transform.position;

        count = initialCount;
    }
	
	// Update is called once per frame
	void Update () {
        spawnTime -= Time.deltaTime;
        // skal rettes til at udregnes baseret på enemy wave level
        if (spawnTime <= 0 && minionCount <= 0 && !done) {
            minionCount = 10;
            spawning = true;
            done = true;
        }
     
        if (spawning) {
            count -= Time.deltaTime;
            if (count <= 0 && minionCount > 0) {
                SpawnEnemy();
                minionCount--;
                count = initialCount;
            }
        }

	}

    bool SpawnEnemy() {

        /*
         Tag spawnTime modulo 2 og spawn en minion hver gang spawnTime % 2 = 0 
         Brug absolute værdi til at vende negative tal til positive.
         reset spawnTime og minion count efter 10 spawns
         
         */
  
        bool waveSpawned = false;

        Instantiate(Warrior, enemySpawnPoint, Quaternion.identity);

        /*
        for (int i = 0; i < minionCount; i++){

                Instantiate(Warrior, enemySpawnPoint, Quaternion.identity);
                waveSpawned = true;
            }
        */
            return waveSpawned;
    }

}
