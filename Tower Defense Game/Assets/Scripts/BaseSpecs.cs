using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpecs : MonoBehaviour {
    GameObject overlord = GameObject.FindGameObjectWithTag("Overlord");
    bool gameover = false;

    [Header("Setup")]
    public int health;

    void OnTriggerEnter(Collider Other) {
        if (Other.tag == "Enemy") {
            health--;
            if (health <= 0) {
                gameover = true;
                Destroy(Other.gameObject);
                overlord.GetComponent<Overlord>().DecreaseMinionCount();
                Destroy(gameObject);
            }
            else
            {
                Destroy(Other.gameObject);
                overlord.GetComponent<Overlord>().DecreaseMinionCount();
            }
        }
    }// OnTriggerEnter end

    public void ReduceHealth(int amount)
    {
        health = health - amount;
    }
}
