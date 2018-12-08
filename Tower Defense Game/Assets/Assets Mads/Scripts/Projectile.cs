using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private GameObject target;
    private float speed;
    private int damageAmount;
    private string damageType;

    void Update()
    {
        Movement movement = GetComponent<Movement>();
        movement.setSpeed(speed);
        gotTarget();
        if (movement.Reached(target))
            Damage(target);
        movement.moveTo(target);       
    }

    void gotTarget()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Damage(GameObject target)
    {
        target.GetComponent<Health>().TakeDamage(damageAmount, damageType);
        Destroy(this.gameObject);
    }

    //setters
    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setDamageAmount(int damageAmount)
    {
        this.damageAmount = damageAmount;
    }

    public void setType(string damageType)
    {
        this.damageType = damageType;
    }

}
