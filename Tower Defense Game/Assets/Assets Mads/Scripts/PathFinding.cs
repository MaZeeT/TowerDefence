using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

    GameObject overlord;
    //GameObject playerBase, enemyPath, enemySpawn; Un-used for now

    private bool reportIntel;

    [Header("Pathing")]
    public GameObject pathList;
    List<GameObject> path;
    public int pathIndex;

    void Start()
    {
        overlord = GameObject.FindGameObjectWithTag("Overlord");
        path = pathList.gameObject.GetComponent<PathPointList>().getPathList();
    }

    void Update()
    {
        reportIntel = GetComponent<Intel>().reportIntel;
        if (reportIntel)
        {
            GetComponent<Movement>().moveTo(path[pathIndex]);
            //moveTo(path[pathIndex]);
        }
        else
        {
            GetComponent<Movement>().moveTo(path[pathIndex + 1]);
            //moveTo(path[pathIndex + 1]);
        }
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "PathPoint" && reportIntel == false)
        {
            pathIndex++;
        }
        else if (Other.tag == "EnemySpawn" && reportIntel == true)
        {
            EnemyWaves enemy = overlord.GetComponent<EnemyWaves>();
            Destroy(gameObject);
        }
        else if (Other.tag == "PathPoint" && reportIntel == true)
        {
            pathIndex--;
        }
    }

}