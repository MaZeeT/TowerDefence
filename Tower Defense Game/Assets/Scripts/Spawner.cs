using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The purpose of this script is to enable the spawner to instantiate minions depending on input 
 */

public class Spawner : MonoBehaviour
{

    // this instantiate the minion into the unity scene
    private void InstantiateMinion(GameObject minion, Vector3 spawnPoint)
    {
        GameObject newMinion;
        newMinion = GameObject.Instantiate(minion, spawnPoint, Quaternion.identity);
    }

    // here are 2 overloaded methods to pass this script a minion to spawn
    public void Spawn(GameObject minionType, GameObject path)
    {
        Vector3 vector = transform.position;
        minionType.GetComponent<PathFinding>().SetPathList(path);
        InstantiateMinion(minionType, vector);
    }

    public void Spawn(GameObject minionType)
    {
        Vector3 vector = transform.position;
        InstantiateMinion(minionType, vector);
    }

    // below is variables and Update function to test spawning 
    [Header("testing Settings")]
    public bool testing;
    private float time;
    public float periode = 2;
    public GameObject testPath;
    public GameObject testMinion;

    void Update()
    {
        if (time > periode && testing == true)
        {
            time = 0;
            Spawn(testMinion, testPath);
        }
        time = time + Time.deltaTime;
    }
}
