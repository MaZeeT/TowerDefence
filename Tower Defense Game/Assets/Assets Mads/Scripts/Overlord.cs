﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour {

    float initialSpawntime = 30f;

    [Header("Setup")]
    public GameObject spawner;
    public GameObject Warrior;
    /*
    public GameObject TwoHandedWarrior;
    public GameObject Archer;
    public GameObject BruteWarrior;
    public GameObject Crossbow;
    public GameObject HammerWarrior;
    public GameObject KarateWarrior;
    public GameObject Mage;
    public GameObject Ninja;
    public GameObject Sorceress;
    public GameObject Spearman;
    public GameObject Swordsman;
    */

    [Header("Wave Stats")]
    public string msg;
    public float spawnTime;
    public int waveCount = 0;
    public float count;
    public int minionSpawning = 0;
    public int minionsAlive = 0;

    Vector3 enemySpawnPoint;
    float initialCount = 4f;
    bool spawning = false, done = false, allDead;

    // Use this for initialization
    void Start()
    {
        enemySpawnPoint = spawner.transform.position;

        count = initialCount;
        //spawnTime = initialSpawntime;
    }// Start end

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        // skal rettes til at udregnes baseret på enemy wave level
        if (msg == "I'm fucked")
        {
            msg = "";
            SpawnEnemy();
            Debug.Log("spawned");
        }
        SpawnWave();
    }// Update end

    void SpawnEnemy()
    {
        GameObject test = GameObject.Instantiate(Warrior, enemySpawnPoint, Quaternion.identity) as GameObject;
        EnemySpecs testE = test.GetComponent<EnemySpecs>();
        testE.weakness = "Water";
        testE.resistance = "Fire";

        minionsAlive++;
    }// SpawnEnemy end

    void SpawnWave()
    {
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
            }
            else if (minionSpawning == 0)
            {
                spawning = false;
            }
        }
    }// SpawnWave end

    public void MinionDead(int minionAmount)
    {
        minionsAlive -= minionAmount;
        if (minionsAlive <= 0 && done)
        {
            spawnTime = initialSpawntime;
            done = false;
        }
    }/// MinionDead end
}
