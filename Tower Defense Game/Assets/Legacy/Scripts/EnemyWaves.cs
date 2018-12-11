using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [Header("Wave Stats")]
    public string msg;
    public int minionsAlive;
    public float spawnTime;
    public float initialSpawntime;

    float initialCount = 4f;
    bool spawning = false, done = false, allDead;

    void Start()
    {        
     
    }            
         
    public void MinionDead(int minionAmount)
    {
        minionsAlive -= minionAmount;
        if (minionsAlive <= 0 && done)
        {
            spawnTime = initialSpawntime;
            done = false;
        }
    }
}