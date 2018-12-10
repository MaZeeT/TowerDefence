using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private Transform target;

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
    {   //the different damageTypes the bullet can deal
        physical,
        fire,
        water,
        lightning
    };
    public DropDown damageType;

    // Use this for initialization
    void Start () {
        InvokeRepeating("FindTarget", 0f, 0.5f);
	}// Start end

    void FindTarget() {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            //EnemySpecs specs = enemy.GetComponent<EnemySpecs>();
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else { 
            target = null;
        }
    }// FindTarget end

	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            return;
        }

        Vector3 dirToEnemy = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dirToEnemy);
        Vector3 rotation = targetRotation.eulerAngles;
        towerRotation.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }// Update end

    void Shoot() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.type = damageType.ToString();
      //  Debug.Log(bullet.type);

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }// Shoot end

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }// OnDrawGizmosSelected end
}
