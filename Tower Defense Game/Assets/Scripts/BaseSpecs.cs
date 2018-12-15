using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * the purpose of this script is to add functionallity to the base, 
 * so it can report to the overlord if it has taken damaged and despawned a minion
 */

public class BaseSpecs : MonoBehaviour
{
    GameObject overlord;
    bool gameover = false;

    [Header("Setup")]
    public int health;

    private void Start()
    {
        overlord = GameObject.FindGameObjectWithTag("Overlord");
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy")
        {
            health--;
            if (health <= 0)
            {
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
    }

    public void ReduceHealth(int amount)
    {
        health = health - amount;
    }
}