using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBullet : MonoBehaviour {


    public GameObject TowerFoundation;
    public GameObject BuildingBall;
    float speed = 1f;
    public string buildString;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(buildString != null) {
            gameObject.transform.Translate(transform.forward * ((speed * Time.deltaTime) * -1));
        }
    }

    void onCollideEnter() {

        Vector3 vec = new Vector3(transform.position.x, 0.01f, transform.position.z);

        if (buildString == "TowerFoundation")
        {
            Instantiate(TowerFoundation, vec, Quaternion.identity);
        }
        if (buildString == "BuildingBall")
        {
            Instantiate(BuildingBall, vec, Quaternion.identity);
        }

    }
}
