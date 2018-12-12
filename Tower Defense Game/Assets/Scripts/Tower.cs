using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private GameObject target;

    [Header("Attributes")]
    public float range;
    public float roundsPerMinut;
    private float reloadTime;
    public float reloadProgress = 0f;

    [Header("Projectile Settings")]
    public float speed;
    public int damageAmount;
    public DropDown damageType;

    [Header("Setup")]
    // public string enemyTag = "Enemy";
    public Transform towerRotation;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public enum DropDown
    {   //the different damageTypes the bullet can deal, in a list in unity
        physical,
        fire,
        water,
        lightning
    };
    

    void Start()
    {
        reloadTime = 60.0f / roundsPerMinut;        
    }

    void Update()
    {
        target = GetComponent<Targeting>().FindTarget(range);
        if (target == null)
            return;       
        Aim(target);
        if (reloading() == false)
        {            
            Shoot(target);
            reloadProgress = 0;
        }
    }

    bool reloading()
    {
        if (reloadTime >= reloadProgress)
        {
            reloadProgress += Time.deltaTime;
            return true;
        }
        else
        {           
            return false;
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
        GameObject bullet = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Projectile>().setTarget(target);
        bullet.GetComponent<Projectile>().setSpeed(speed);
        bullet.GetComponent<Projectile>().setDamageAmount(damageAmount);
        bullet.GetComponent<Projectile>().setType(damageType.ToString());
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }


    //Getters and setters
    public GameObject GetTarget()
    {
        return target;
    }

    public void setDamage(int damage)
    {
        this.damageAmount = damage;
    }

    public void setRange(float range)
    {
        this.range = range;
    }

    public float getRange()
    {
        return this.range;
    }

    public int getDamage()
    {
        return this.damageAmount;
    }

    public string getDamageType()
    {
        return damageType.ToString();
    }

    public float getDamagePerMinut()
    {
        return damageAmount * roundsPerMinut;
    }
}
