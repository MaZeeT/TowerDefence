using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpecs : MonoBehaviour {

    bool gameover = false;

    [Header("Setup")]
    public int Health;

	// Use this for initialization
	void Start () {
		
	}//Start end
	
	// Update is called once per frame
	void Update () {
		
	}// Update end

    void OnTriggerEnter(Collider Other) {
        if (Other.tag == "Enemy") {
            Health--;
            if (Health <= 0) {
                gameover = true;
                Destroy(Other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(Other.gameObject);
            }
        }
    }// OnTriggerEnter end
}
