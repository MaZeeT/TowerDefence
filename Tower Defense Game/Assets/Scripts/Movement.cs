using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [Header("Movement")]
    public float moveSpeed;


    private bool HaveReached(Vector3 direction)
    {
        if (direction.magnitude <= moveSpeed * Time.deltaTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void move(Vector3 direction)
    {
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    public void setSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    // Public overloaded caller function for core logic
    public bool Reached(GameObject target)
    {
            Vector3 dir = target.transform.position - transform.position;
            return HaveReached(dir);   
    }

    public bool Reached(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        return HaveReached(dir);
    }

    public void moveTo(GameObject point)
    {
        Vector3 direction = point.transform.position - transform.position;
        move(direction);
    }

    public void moveTo(Transform point)
    {
        Vector3 direction = point.position - transform.position;
        move(direction);
    }
}
