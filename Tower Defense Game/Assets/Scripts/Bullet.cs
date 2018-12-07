using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 50f;
    public int damage = 2;
    public string type;

    public void Seek(Transform _target) {
        target = _target;
    }
	
	void Update () {

        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            DamageTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void DamageTarget() {
        Health e = target.GetComponent<Health>();   
        e.TakeDamage(damage,type);
        Destroy(gameObject);
    }
}
