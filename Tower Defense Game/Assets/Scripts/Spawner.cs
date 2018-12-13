using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    List<GameObject> pathList;

    //public Vector3 spawnPoint;
    
    public void Spawn(GameObject minionType)
    {        
        Vector3 vector = transform.position;       
        InstantiateMinion(minionType, vector);
    }

    private void InstantiateMinion(GameObject minion, Vector3 spawnPoint)
    {
        GameObject newMinion;
        newMinion = GameObject.Instantiate(minion, spawnPoint, Quaternion.identity);
    }


    // below is variables and Update function to test spawning 
    [Header("testing Settings")]
    public bool testing;
    private float time;
    public float periode = 2;    
    public GameObject testPath;
    public GameObject testMinion;

    void Update () {
        if (time > periode && testing == true)
        {
            time = 0;
            Spawn(testMinion);
        }
        time = time + Time.deltaTime;
    }
}
