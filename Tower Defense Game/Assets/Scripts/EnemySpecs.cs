using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecs : MonoBehaviour {

    public int health = 5;

	// Use this for initialization
	void Start () {
		
	}

    public void Damaged(int amount) {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
