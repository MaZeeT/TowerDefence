using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    GameObject overlord;
    //GameObject playerBase, enemyPath, enemySpawn; Un-used for now

    private bool reportIntel;

    [Header("Movement")]
    public float moveSpeed;
    public GameObject pathList;
    List<GameObject> path;
    public int pathIndex;

    void Start () {
        overlord = GameObject.FindGameObjectWithTag("Overlord");
        path = pathList.gameObject.GetComponent<PathPointList>().getPathList();
    }
	
	void Update (){
        reportIntel = GetComponent<Intel>().reportIntel;
        if (reportIntel){
            moveTo(path[pathIndex]);
        }
        else{
            moveTo(path[pathIndex + 1]);
        }
    }

    void moveTo(GameObject point)
    {
        Vector3 direction = point.transform.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
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
    }// OnTriggerEnter end

}
