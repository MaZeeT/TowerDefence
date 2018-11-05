using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreation : MonoBehaviour {

    public GameObject theFirstTower;
    Transform creatPos;
   
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update() {
        
    }

    void createStructure() {

      Instantiate(theFirstTower, creatPos.position, Quaternion.identity);
       
    }
    void OnCollisionEnter(Collision matCol) {
        if (matCol.gameObject.tag == "buildMaterial") {
            creatPos = matCol.gameObject.transform;
            createStructure();
            Destroy(matCol.gameObject);
            Destroy(gameObject);
        }
    }
}   

