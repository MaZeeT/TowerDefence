using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// The purpose of this class is to move a object to a given position, it also have a function to check if it will reach the position within the next frame
//

public class Movement : MonoBehaviour {

    [Header("Movement")]
    public float moveSpeed;


    // check if the object will reach its target within the next frame
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

    // this function handle the movement of the object.
    private void move(Vector3 direction)
    {
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    public void setSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    // Below are the public functions which are overloaded to call the private move() function
    // this is to ensure that whatever type is given it can be converted to a point the move() function understands.
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
