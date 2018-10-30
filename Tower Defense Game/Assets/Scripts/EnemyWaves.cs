using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    float initialSpawntime = 30f;
    public float spawnTime = 0;
    public int minionsAlive = 0;
    public int minionSpawning = 0;
    public int waveCount = 0;
    GameObject Overlord, Warrior, enemySpawn;
    Vector3 enemySpawnPoint;
    float initialCount = 4f;
    public float count;
    bool spawning = false, done = false;

    // Use this for initialization
    void Start()
    {
        Overlord = GameObject.FindGameObjectWithTag("Overload");
        Warrior = GameObject.FindGameObjectWithTag("Enemy");
        enemySpawn = GameObject.FindGameObjectWithTag("EnemySpawn");
        enemySpawnPoint = enemySpawn.transform.position;

        count = initialCount;
        spawnTime = initialSpawntime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        // skal rettes til at udregnes baseret på enemy wave level
         spawnWave();

    }

    bool SpawnEnemy()
    {


        /*
         Tag spawnTime modulo 2 og spawn en minion hver gang spawnTime % 2 = 0 
         Brug absolute værdi til at vende negative tal til positive.
         reset spawnTime og minion count efter 10 spawns
         
         */

        bool waveSpawned = false;

        Instantiate(Warrior, enemySpawnPoint, Quaternion.identity);
        minionsAlive++;
        /*
        for (int i = 0; i < minionSpawning; i++){

                Instantiate(Warrior, enemySpawnPoint, Quaternion.identity);
                waveSpawned = true;
            }
        */
        return waveSpawned;

    }
    public void minionDead() {

        minionsAlive--;

    }

    void spawnWave() {

        if (spawnTime <= 0 && minionSpawning <= 0 && !done)
        {
            minionSpawning = 10;
            spawning = true;
            done = true;
         }
        if (spawning)
        {
            count -= Time.deltaTime;
            if (count <= 0 && minionSpawning > 0)
            {
                SpawnEnemy();
                minionSpawning--;
                count = initialCount;
            } else if (minionSpawning == 0) {
                spawning = false;
                spawnTime = initialSpawntime;
                done = false;

            }
        }
    }
}
