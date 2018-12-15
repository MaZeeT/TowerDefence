using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The purpose of this class is to enable a minion to move along a path, this is implementet by following a list of positions the minion will have to move to.
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
        isReportIntel = intel.reportIntel; //get if Intel script want to report to overlord (return back the path)

        // lower the pathIndex until at 0 for moving to spawner
        if (movement.Reached(path[pathIndex]) && isReportIntel == true && pathIndex != 0) pathIndex--;

        // if reporting so early that you haven't left spawner, this destroy gameobject sincec a collider will not happen
        if (movement.Reached(path[0]) && isReportIntel == true) Destroy(gameObject);

        // let you change direction of movement between 2 pathpoints
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
        // control the pathIndex depending on if moving toward base or spawner
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
            overlord.GetComponent<Overlord>().receiveSpotList(intel.getSpottedList(), pathList);
            Destroy(gameObject);
        }
        else if (Other.tag == "Base")
        {
            Other.GetComponent<BaseSpecs>().ReduceHealth(1);
            Destroy(gameObject);
        }   
    }


    // setters and getter
    public void setPathList(GameObject pathList)
    {
        this.pathList = pathList;
    }

    public void setPathList(List<GameObject> pathList)
    {
        this.path = pathList;
    }    

    public GameObject GetPathList()
    {
        return path;
    }
}