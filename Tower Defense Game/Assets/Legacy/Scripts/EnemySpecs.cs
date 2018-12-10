using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecs : MonoBehaviour {

    GameObject overlord, playerBase, enemyPath, enemySpawn;
    List<GameObject>fleePath = new List<GameObject>();
    public bool flee = false;
    string msg;
    public string weakness;
    public string resistance;
 
    [Header("Minion Stats")]
    public int health = 20;
    public string type;
    public GameObject nextPoint;
   
    // Use this for initialization
    void Start () {
        enemySpawn = GameObject.FindGameObjectWithTag("EnemySpawn");
        enemyPath = GameObject.FindGameObjectWithTag("EnemyPath");
        playerBase = GameObject.FindGameObjectWithTag("Base");
        overlord = GameObject.FindGameObjectWithTag("Overlord");
        nextPoint = enemyPath;
        fleePath.Add(enemySpawn);
        msg = "I'm fine";
    }// Start end

    // Update is called once per frame
    void Update()
    {
        if (flee) {
            nextPoint = fleePath[fleePath.Count-1];
        }
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
            if (flee == false)
            {
                fleePath.Add(Other.gameObject);
                List<GameObject> pathPoints = Other.gameObject.GetComponent<PathPoints>().GetBetterList();
                int randomNumber = Random.Range(0, pathPoints.Count);
                MovePoint(pathPoints[randomNumber]);
            }
            else {
                fleePath.RemoveAt(fleePath.Count - 1);
            }
        } else if (Other.tag == "EnemySpawn" && flee == true)
        {
            EnemyWaves enemy = overlord.GetComponent<EnemyWaves>();
            enemy.msg = this.msg;
            Destroy(gameObject);
        }
    }// OnTriggerEnter end

    public void Damaged(int damageValue, string type)
    {
       // Debug.Log(type);
        Debug.Log(weakness);
        if (weakness == type)
        {
            health -= damageValue * 2;
            Debug.Log("weak");
        }
        else if (resistance == type)
        {
            health -= damageValue / 2;
            Debug.Log("Strong");
        }
        else {
            health -= damageValue;
            Debug.Log("normal");
        }
       
       // flee = true;
        msg = "I'm fucked";
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
