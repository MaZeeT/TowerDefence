using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

    GameObject overlord, playerBase, enemyPath, enemySpawn;
    public bool flee = false;
    string msg;

    [Header("Minion Stats")]
    public int health = 5;
    public float moveSpeed;

    [Header("Variables")]
    public GameObject pathList;
    List<GameObject> path;
    public int pathIndex;


    // Use this for initialization
    void Start () {
        path = pathList.gameObject.GetComponent<PathPointList>().getPathList();
    }// Start end

    // Update is called once per frame
    void Update()
    {      
        if (flee){
            moveTo(path[pathIndex]);
        }
        else {
            moveTo(path[pathIndex+1]);
        }// if ends
    }// Update end

    void moveTo(GameObject point)
    {
        Vector3 direction = point.transform.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider Other) {
        if (Other.tag == "PathPoint" && flee == false) {
            pathIndex++;
        }
        else if (Other.tag == "EnemySpawn" && flee == true){
            EnemyWaves enemy = overlord.GetComponent<EnemyWaves>();
            enemy.msg = this.msg;
            Destroy(gameObject);
        }
        else if (Other.tag == "PathPoint" && flee == true){
            pathIndex--;
        }                
    }// OnTriggerEnter end

    public void Damaged(int damageValue)
    {
        health -= damageValue;
        flee = true;
        generateIntel(); // need to be moved. at the moment it generate intel when fired on.
        if (health <= 0)
        {
            EnemyWaves enemy = overlord.GetComponent<EnemyWaves>();
            enemy.MinionDead(1);
            Destroy(gameObject);
        }
    }// Damaged end

    void generateIntel()
    {
        msg = "I'm fucked";
    }
}
