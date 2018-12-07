using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [Header("Defensive Stats")]
    public float health;
    public int resistancePhysical;
    public int resistanceFire;
    public int resistanceWater;
    public int resistanceLightning;
    private int resistance;

    public void TakeDamage (int damageValue, string damageType)
    {
        
        switch (damageType)
        {
            case "physical":
                resistance = resistancePhysical;
                Debug.Log("Physical dmg");
                break;
            case "fire":
                resistance = resistanceFire;
                Debug.Log("Fire dmg");
                break;
            case "water":
                resistance = resistanceWater;
                Debug.Log("Water dmg");
                break;
            case "lightning":
                resistance = resistanceLightning;
                Debug.Log("Lightning dmg");
                break;
        }
        
        health = health - (float)damageValue * ((float)(100-resistance) / 100);
        
        if (health <= 0)
        {
            Destroy(gameObject);

            //the 2 below breaks this if statements and the Minion will not despawn on 0hp

            //EnemyWaves enemy = overlord.GetComponent<EnemyWaves>();
            //enemy.MinionDead(1);
        }
    }// Damaged end
}
