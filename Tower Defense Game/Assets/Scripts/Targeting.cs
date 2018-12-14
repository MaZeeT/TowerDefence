using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour {
    public string targetTag;   

    public GameObject FindTarget(float range)    
    {
        GameObject nearestTarget = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(targetTag);
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject target in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestTarget = target; //.GetComponent<Health>().hitbox;
            }
        }

        if (nearestTarget != null && shortestDistance <= range)
        {
            return nearestTarget as GameObject;           
        }
        else
        {
            return null;
        }
    }
}
