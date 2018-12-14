using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// The purpose of this clas is to different some behaivours to our projectiles fired from the towers
//

public class Projectile : MonoBehaviour {
    private GameObject target;
    private float speed;
    public int damageAmount;
    private string damageType;

    void Update()
    {
        Movement movement = GetComponent<Movement>();
        movement.setSpeed(speed);
        gotTarget();

        if (gotTarget() == true)
        {
            // checks if the projectile will hit the target in the next frame, if true it will damage the target and despawn.
            if (movement.Reached(target))
                Damage(target);
            movement.moveTo(target);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // check if the target is still alive else it despawns the projectile.
    bool gotTarget()
    {
        if(target == null)
        {   
            return false;
        }
        else
        {
            return true;
        }
    }

    // damage target when hit
    void Damage(GameObject target)
    {
        target.GetComponent<Health>().TakeDamage(damageAmount, damageType, target.tag);
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
