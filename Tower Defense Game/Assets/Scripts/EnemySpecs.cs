using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecs : MonoBehaviour {

    GameObject nextPoint, overlord, playerBase, enemyPath;

    [Header("Minion Stats")]
    public int health = 5;
   
	// Use this for initialization
	void Start () {
        enemyPath = GameObject.FindGameObjectWithTag("EnemyPath");
        playerBase = GameObject.FindGameObjectWithTag("Base");
        overlord = GameObject.FindGameObjectWithTag("Overlord");
        nextPoint = enemyPath;
    }// Start end

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;
        if (nextPoint.transform.position.x != currentPosition.x && nextPoint.transform.position.x > currentPosition.x)
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        }
        else if (nextPoint.transform.position.x != currentPosition.x && nextPoint.transform.position.x < currentPosition.x)
        {
            transform.position += new Vector3(1 * Time.deltaTime * -1, 0, 0);
        }

        if (nextPoint.transform.position.z != currentPosition.z && nextPoint.transform.position.z > currentPosition.z)
        {
            transform.position += new Vector3(0, 0, 1 * Time.deltaTime);
        }
        else if (nextPoint.transform.position.z != currentPosition.z && nextPoint.transform.position.z < currentPosition.z)
        {
            transform.position += new Vector3(0, 0, 1 * Time.deltaTime * -1);
        }

    }// Update end

    void OnTriggerEnter(Collider Other) {
        if (Other.tag == "PathPoint") {
            MovePoint(Other.gameObject.GetComponent<PathPoints>().pathF);
        }
    }// OnTriggerEnter end

    public void Damaged(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            EnemyWaves enemy = overlord.GetComponent<EnemyWaves>();
            enemy.MinionDead(1);    
            Destroy(gameObject);
           
        }
    }// Damaged end

    public void MovePoint(GameObject nextPoint) {
        this.nextPoint = nextPoint;
    }// MovePoint end
}
