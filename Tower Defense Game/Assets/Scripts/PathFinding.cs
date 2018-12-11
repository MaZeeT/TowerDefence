using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

    GameObject overlord;
    Movement movement;
    Intel intel;
    bool isReportIntel;

    [Header("Pathing")]
    public GameObject pathList;
    List<GameObject> path;
    public int pathIndex;

    void Start()
    {
        overlord = GameObject.FindGameObjectWithTag("Overlord");
        movement = GetComponent<Movement>();
        intel = GetComponent<Intel>();
        path = pathList.gameObject.GetComponent<PathPointList>().getPathList();
    }

    void Update()
    {
        if (pathIndex != 0) isReportIntel = intel.reportIntel;

        if (movement.Reached(path[pathIndex]) && isReportIntel == true) pathIndex--;

        if (isReportIntel)
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
        if (Other.tag == "PathPoint" && isReportIntel == false)
        {
            pathIndex++;
        }
        else if (Other.tag == "PathPoint" && isReportIntel == true)
        {
            pathIndex--;
        }
        else if (Other.tag == "EnemySpawn" && isReportIntel == true)
        {
            EnemyWaves enemy = overlord.GetComponent<EnemyWaves>();
            Destroy(gameObject);
        }
        else if (Other.tag == "Base")
        {
            Other.GetComponent<BaseSpecs>().ReduceHealth(1);
            Destroy(gameObject);
        }   
    }

    public void setPathList(GameObject pathList)
    {
        this.pathList = pathList;
    }

    public void setPathList(List<GameObject> pathList)
    {
        this.path = pathList;
    }    
}