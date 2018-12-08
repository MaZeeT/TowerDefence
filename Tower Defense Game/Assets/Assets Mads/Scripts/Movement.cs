using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [Header("Movement")]
    public float moveSpeed;

    public void moveTo(GameObject point)
    {
        Vector3 direction = point.transform.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

}
