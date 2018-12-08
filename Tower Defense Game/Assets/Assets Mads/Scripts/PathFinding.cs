using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

    GameObject overlord;
    Movement movement;
    bool reportIntel;

    [Header("Pathing")]
    public GameObject pathList;
    List<GameObject> path;
    public int pathIndex;

    void Start()
    {
        movement = GetComponent<Movement>();
        overlord = GameObject.FindGameObjectWithTag("Overlord");
        path = pathList.gameObject.GetComponent<PathPointList>().getPathList();
    }

    void Update()
    {
        if (pathIndex != 0) reportIntel = GetComponent<Intel>().reportIntel;

        if (movement.Reached(path[pathIndex]) && reportIntel == true) pathIndex--;

        if (reportIntel)
        {
            movement.moveTo(path[pathIndex]);
        }
        else
        {
            movement.moveTo(path[pathIndex + 1]);
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