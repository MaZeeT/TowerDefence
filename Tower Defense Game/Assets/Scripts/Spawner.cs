using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    List<GameObject> pathList;

    public PathPointList testPath;
    public GameObject testMinion;

    void Spawn(GameObject minionType, PathPointList path)
    {
        pathList = path.getPathList();
        Vector3 goTo = pathList[0].transform.position - transform.position;
        GameObject newMinion = GameObject.Instantiate(minionType, goTo, Quaternion.identity) as GameObject;
    }

    void test()
    {
        Spawn(testMinion, testPath);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float wave = 4;
        float time = 4;
        if (time <= Time.deltaTime)
        {
            time = time + Time.deltaTime;
            test();
        }
	}
}
