using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GameObject overlord;

    [Header("Defensive Stats")]
    public float health;
    public int resistancePhysical;
    public int resistanceFire;
    public int resistanceWater;
    public int resistanceLightning;
    private int resistance;

    public void TakeDamage(int damageValue, string damageType, string objTag)
    {
        switch (damageType)
        {
            case "physical":
                resistance = resistancePhysical;                
                break;
            case "fire":
                resistance = resistanceFire;                
                break;
            case "water":
                resistance = resistanceWater;                
                break;
            case "lightning":
                resistance = resistanceLightning;                
                break;
        }

        health = health - (float)damageValue * ((float)(100 - resistance) / 100);

        if (health <= 0)
        {
            overlord.GetComponent<Overlord>().DecreaseMinionCount();
            Destroy(gameObject);
        }
    }

    void Start()
    {
        overlord = GameObject.FindGameObjectWithTag("Overlord");
        overlord.GetComponent<Overlord>().IncreaseMinionCount();
    }
}
