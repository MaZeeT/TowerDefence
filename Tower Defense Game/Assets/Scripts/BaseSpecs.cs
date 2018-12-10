using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpecs : MonoBehaviour {

    bool gameover = false;

    [Header("Setup")]
    public int Health;

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
