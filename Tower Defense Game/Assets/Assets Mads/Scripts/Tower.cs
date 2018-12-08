using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private GameObject target;

    [Header("Attributes")]
    public float range = 10f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Setup")]
    public string enemyTag = "Enemy";
    public Transform towerRotation;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public enum DropDown
    {   //the different damageTypes the bullet can deal, in a list in unity
        physical,
        fire,
        water,
        lightning
    };
    public DropDown damageType;

    void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    void Update()
    {
        FindTarget();
        if (target == null)
        {
            return;
        }
        Aim(target);
        if (fireCountdown <= 0f)
        {
            
            Shoot(target);
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void FindTarget()
    {
        GameObject nearestTarget = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
         
        foreach (GameObject target in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestTarget = target;
            }
        }

        if (nearestTarget != null && shortestDistance <= range)
        {
            target = nearestTarget;
        }
        else
        {
            target = null;
        }
    }



    void Aim(GameObject target)
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = targetRotation.eulerAngles;
        towerRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot(GameObject target)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Projectile>().setType(damageType.ToString());
        bullet.GetComponent<Projectile>().setTarget(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
