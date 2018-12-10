using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFlameThrower : MonoBehaviour {

    public GameObject flameThrower;
    private GameObject target;

    private void Update()
    {
        target = GetComponent<Tower>().GetTarget();
        if (target == null)
        {
            flameThrower.SetActive(false);
        }
        else
        {
            flameThrower.SetActive(true);
        }
    }
}
