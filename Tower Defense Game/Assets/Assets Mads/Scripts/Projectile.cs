using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private GameObject target;

    public float speed = 50f;
    public int damage = 2;
    private string type;

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public void setType(string type)
    {
        this.type = type;
    }

    void Update()
    {
        gotTarget();
        //checkMagnitude();
        GetComponent<Movement>().moveTo(target);
        
    }

    void gotTarget()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    /*
    void checkMagnitude()
    {
        if (dir.magnitude <= speed * Time.deltaTime)
        {
            DamageTarget();
            return;
        }
    }*/

    void DamageTarget()
    {
        Health e = target.GetComponent<Health>();
        e.TakeDamage(damage, type);
        Destroy(this.gameObject);
    }

}
