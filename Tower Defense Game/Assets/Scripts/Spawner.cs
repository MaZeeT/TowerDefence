using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    List<GameObject> pathList;

    public GameObject testPath;
    public GameObject testMinion;
    public Vector3 spawnPoint;
                

    void Spawn(GameObject minionType, GameObject path)
    {
        Vector3 vector;
        vector = transform.position;
        InstantiateMinion(minionType, vector, path);

        //GameObject test = GameObject.Instantiate(Warrior, enemySpawnPoint, Quaternion.identity) as GameObject;

        //pathList = path.GetPathList();
        //Vector3 goTo = pathList[0].transform.position - transform.position;
        //GameObject newMinion = GameObject.Instantiate(minionType, spawnLocation, Quaternion.identity) as GameObject;


        // spawnPoint = transform.position;    
        // GameObject minion = GameObject.Instantiate(minionType, spawnPoint, Quaternion.identity) as GameObject;
        // minion.GetComponent<PathFinding>().setPathList(path);
    }

    void InstantiateMinion(GameObject minion, Vector3 spawnPoint, GameObject path)
    {
        GameObject newMinion;
        newMinion = GameObject.Instantiate(minion, spawnPoint, Quaternion.identity);
        newMinion.GetComponent<PathFinding>().setPathList(path);
    }

    void Test()
    {
        Spawn(testMinion, testPath);
    }
	
	// Update is called once per frame
	void Update () {
        float time = 2;
        if (time <= Time.deltaTime)
        {
            time = time + Time.deltaTime;
            Test();
        }
	}
}
