using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpecs : MonoBehaviour {
    GameObject overlord;
    bool gameover = false;

    [Header("Setup")]
    public int health;

    private void Start()
    {
         overlord = GameObject.FindGameObjectWithTag("Overlord");
    }
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
